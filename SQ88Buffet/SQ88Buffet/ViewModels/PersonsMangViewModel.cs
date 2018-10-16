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
    public class PersonsMangViewModel
    {
        public INavigation _navigation;

        public ObservableCollection<PersonOption> PersonOptions { get; set; }
        public ICommand NavigateToPersonOptionCommand { get; private set; }

        public PersonsMangViewModel(INavigation navigation)
        {
            _navigation = navigation;

            PersonOptions = new ObservableCollection<PersonOption>()
            {
                new PersonOption() { Option = "Add person"},
                new PersonOption() { Option = "Update person"},
                new PersonOption() { Option = "Delete person"}
            };
            NavigateToPersonOptionCommand = new Command(async (e) => await NavigateToPersonOption(e));
        }

        private async Task NavigateToPersonOption(object e)
        {
            var pickedOption = (e as PersonOption);
            switch (pickedOption.Option)
            {
                case "Add person":
                    await _navigation.PushAsync(new AddEditPersonPage());
                    break;
                case "Update person":
                    await _navigation.PushAsync(new UpdatePersonPage());
                    break;
                case "Delete person":
                    await _navigation.PushAsync(new DeletePersonPage());
                    break;
            }
        }
    }

    public class PersonOption
    {
        public string Option { get; set; }
    }
}
