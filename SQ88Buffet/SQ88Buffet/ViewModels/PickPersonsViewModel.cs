using SQ88Buffet.Models;
using SQ88Buffet.Services;
using SQ88Buffet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class PickPersonsViewModel : BasePersonViewModel
    {
        public ICommand ViewAllPersonsCommand { get; private set; }
        public ICommand ClickOnPersCommand { get; private set; }
        public ICommand NavigateToDeletePersPageCommand { get; private set; }
        public ICommand ChangeRankToOfficersCommand { get; private set; }
        public ICommand ChangeRankToWOfficersCommand { get; private set; }
        public ICommand ChangeRankToSoldiersCommand { get; private set; }

        bool _burchaseOngoing = false;
        List<Purchase> purchasesToAddPerson;

        public PickPersonsViewModel(INavigation navigation, bool burchaseOngoing = false, List<Purchase> purchases = null)
        {
            _navigation = navigation;
            _person = new Person();
            _personRepository = new PersonRepository();

            PersonsList = new ObservableCollection<Person>();
            Rank = "Officer";

            _burchaseOngoing = burchaseOngoing;
            purchasesToAddPerson = new List<Purchase>();

            if(purchases != null)
            {
                purchasesToAddPerson = purchases;
            }

            ClickOnPersCommand = new Command(async (e) => await ClickOnPers(e));
            NavigateToDeletePersPageCommand = new Command(async (e) => await NavigateToDeletePersPage(e));

            ChangeRankToOfficersCommand = new Command(async (e) => await ChangeRankToOfficers(e));
            ChangeRankToWOfficersCommand = new Command(async (e) => await ChangeRankToWOfficers(e));
            ChangeRankToSoldiersCommand = new Command(async (e) => await ChangeRankToSoldiers(e));

        }

        private async Task ChangeRankToSoldiers(object e)
        {
            Rank = "Soldier";
            await FetchAllPersonsWithRank(Rank);


            StackLayout stack = (e as StackLayout);
            Button officers = stack.FindByName<Button>("BtnOfficers");
            Button wofficers = stack.FindByName<Button>("BtnWOfficers");
            Button soldiers = stack.FindByName<Button>("BtnSoldiers");

            officers.IsEnabled = false;
            wofficers.IsEnabled = true;
            soldiers.IsEnabled = true;
        }

        private async Task ChangeRankToWOfficers(object e)
        {
            Rank = "Warrant Officer";
            await FetchAllPersonsWithRank(Rank);


            StackLayout stack = (e as StackLayout);
            Button officers = stack.FindByName<Button>("BtnOfficers");
            Button wofficers = stack.FindByName<Button>("BtnWOfficers");
            Button soldiers = stack.FindByName<Button>("BtnSoldiers");

            officers.IsEnabled = true;
            wofficers.IsEnabled = false;
            soldiers.IsEnabled = true;
        }

        private async Task ChangeRankToOfficers(object e)
        {
            Rank = "Officer";
            await FetchAllPersonsWithRank(Rank);

            StackLayout stack = (e as StackLayout);
            Button officers = stack.FindByName<Button>("BtnOfficers");
            Button wofficers = stack.FindByName<Button>("BtnWOfficers");
            Button soldiers = stack.FindByName<Button>("BtnSoldiers");

            officers.IsEnabled = false;
            wofficers.IsEnabled = true;
            soldiers.IsEnabled = true;
        }

        public async Task FetchAllPersons()
        {
            PersonsList = new ObservableCollection<Person>(await _personRepository.GetAllPersonsData());
        }
        private async Task FetchAllPersonsWithRank(string rank)
        {
            PersonsList = new ObservableCollection<Person>(
                await _personRepository.GetAllPersonsData(rank));
        }
        private async Task NavigateToDeletePersPage(object e)
        {
            Person selectedPers = (e as Person);
            await _navigation.PushAsync(new AddEditPersonPage(selectedPers, true));
        }

        private async Task ClickOnPers(object e)
        {
            Person selectedPers = (e as Person);

            if (!_burchaseOngoing)
            {
                await _navigation.PushAsync(new AddEditPersonPage(selectedPers));
            }
            else
            {
                foreach (var item in purchasesToAddPerson)
                {
                    item.PersonId = selectedPers.Id;
                    item.PurchaseValue = item.UnitsOfProduct * item.ProductPrice;
                    item.PurchaseDate = DateTime.Now;
                }
                await _navigation.PushAsync(new PurchaseComplete(purchasesToAddPerson));
            }
        }
    }
}
