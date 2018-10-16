using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class AddEditPersonViewModel : BasePersonViewModel
    {
        public ICommand AddPersonCommand { get; private set; }

        bool updateFlag;
        bool deleteFlag;
        public AddEditPersonViewModel(INavigation navigation, Person personToUpdate = null, bool delete = false)
        {
            _navigation = navigation;
            updateFlag = false;

            deleteFlag = delete;

            if (personToUpdate == null)
                _person = new Person();
            else
            {
                _person = personToUpdate;
                updateFlag = true;
            }

            _personRepository = new PersonRepository();

            if (deleteFlag == false)
                AddPersonCommand = new Command(async () => await AddPerson());
            else
                AddPersonCommand = new Command(async () => await DeleteProduct());
        }

        private async Task DeleteProduct()
        {
            if (deleteFlag)
                await _personRepository.DeletePerson(_person.Id);

            await _navigation.PopAsync();
        }

        private async Task AddPerson()
        {
            if (!updateFlag)
                await _personRepository.InsertPerson(_person);
            else
                await _personRepository.UpdatePerson(_person);
            await _navigation.PopAsync();
        }
    }
}
