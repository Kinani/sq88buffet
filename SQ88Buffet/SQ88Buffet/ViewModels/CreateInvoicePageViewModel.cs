using SQ88Buffet.Models;
using SQ88Buffet.Services;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class CreateInvoicePageViewModel
    {
        public INavigation _navigation;
        public PurchaseRepository _purchaseRepository;
        public PersonRepository _personRepository;

        private List<Person> _people;
        //private List<List<Purchase>> _peoplePurchases;
        private decimal _totalNotBilled;
        private decimal _totalAccessoNotBilled;
        private decimal _totalHosNotBilled;
        private List<Purchase> _tempPur;
        private List<Purchase> _tempHospPur;
        private List<Purchase> _tempAccessPur;


        public CreateInvoicePageViewModel(INavigation navigation, List<Person> people)
        {
            _navigation = navigation;

            _purchaseRepository = new PurchaseRepository();
            _personRepository = new PersonRepository();

            _people = new List<Person>(people);
            //_peoplePurchases = new List<List<Purchase>>();

            _tempPur = new List<Purchase>();
            _tempHospPur = new List<Purchase>();
            _tempAccessPur = new List<Purchase>();

            _totalNotBilled = 0;
            _totalAccessoNotBilled = 0;
            _totalHosNotBilled = 0;
        }

        private async Task CalculatePurchasesForPeople()
        {
            foreach (var person in _people)
            {
                _tempPur = await _purchaseRepository.GetPurchasesDataForPerson(person.Id);
                //_peoplePurchases.Add(_tempPur);
                Person personToUpdate = await _personRepository.GetPersonData(person.Id);

                foreach (var item in _tempPur)
                {
                    if (!item.Billed && item.PersonId != 1 && item.PersonId != 2)
                    {
                        _totalNotBilled += item.PurchaseValue;
                        personToUpdate.Balance += item.PurchaseValue;

                    }
                }
                await _personRepository.UpdatePerson(personToUpdate);
            }
        }

        private async Task CalculateAccessoriesForPeople()
        {
            _tempAccessPur = await _purchaseRepository.GetPurchasesDataForPerson(1);
            Person acceoriesAccToUpdate = await _personRepository.GetPersonData(1);

            foreach (var item in _tempAccessPur)
            {
                if (!item.Billed)
                {
                    acceoriesAccToUpdate.Balance += item.PurchaseValue;
                    _totalAccessoNotBilled += item.PurchaseValue;
                }
            }
            await _personRepository.UpdatePerson(acceoriesAccToUpdate);
        }
        private async Task CalculateHospitality()
        {
            _tempHospPur = await _purchaseRepository.GetPurchasesDataForPerson(2);
            Person hospAccToUpdate = await _personRepository.GetPersonData(2);

            foreach (var item in _tempHospPur)
            {
                if (!item.Billed)
                {
                    hospAccToUpdate.Balance += item.PurchaseValue;
                    _totalHosNotBilled += item.PurchaseValue;
                }
            }
            await _personRepository.UpdatePerson(hospAccToUpdate);
        }
        public async Task GenerateReports()
        {
            Assembly assembly = typeof(CreateInvoicePageViewModel).GetTypeInfo().Assembly;
            WordDocument document = new WordDocument();

            WSection section = document.AddSection() as WSection;
            IWParagraph paragraph = section.HeadersFooters.Header.AddParagraph();
            paragraph.AppendText("Testing paragraph header");
            paragraph = section.AddParagraph();
            paragraph.AppendText("Hi again.");

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2010);
            document.Close();

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                await DependencyService.Get<ISaveWindowsPhone>().Save("SQReportTest.docx", "application/msword", stream);
            else
                DependencyService.Get<ISave>().Save("SQReportTest.docx", "application/msword", stream);
        }
    }
}
