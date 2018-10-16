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
        public ICommand NavigateToUpdatePersPageCommand { get; private set; }
        public ICommand NavigateToDeletePersPageCommand { get; private set; }


        public PickPersonsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _person = new Person();
            _personRepository = new PersonRepository();

            PersonsList = new ObservableCollection<Person>();
            Rank = "Officer";

            NavigateToUpdatePersPageCommand = new Command(async (e) => await NavigateToUpdatePersPage(e));
            NavigateToDeletePersPageCommand = new Command(async (e) => await NavigateToDeletePersPage(e));

        }
        public async Task FetchAllPersons()
        {
            PersonsList = new ObservableCollection<Person>(await _personRepository.GetAllPersonsData());
        }
        private async Task FetchAllPersonsWithCategory(string rank)
        {
            PersonsList = new ObservableCollection<Person>(
                await _personRepository.GetAllPersonsData(rank));
        }
        private async Task NavigateToDeletePersPage(object e)
        {
            Person selectedPers = (e as Person);
            await _navigation.PushAsync(new AddEditPersonPage(selectedPers, true));
        }

        private async Task NavigateToUpdatePersPage(object e)
        {
            Person selectedPers = (e as Person);
            await _navigation.PushAsync(new AddEditPersonPage(selectedPers));
        }
    }
}
