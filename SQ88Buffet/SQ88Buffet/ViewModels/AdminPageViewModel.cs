using SQ88Buffet.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class AdminPageViewModel
    {

        public INavigation _navigation;
        

        public ObservableCollection<AdminOption> AdminOptions { get; set; }
        public ICommand NavigateToOptionPageCommand { get; private set; }

        public AdminPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AdminOptions = new ObservableCollection<AdminOption>()
            {
                new AdminOption() { Option = "Products managment"},
                new AdminOption() { Option = "Persons managment"},
                new AdminOption() { Option = "Add accessories"},
                new AdminOption() { Option = "Create invoice"},
                new AdminOption() { Option = "About"}
            };
            NavigateToOptionPageCommand = new Command(async (e) => await NavigateToOptionPage(e));
        }

        private async Task NavigateToOptionPage(object e)
        {
            var pickedOption = (e as AdminOption);
            switch(pickedOption.Option)
            {
                case "Products managment":
                    await _navigation.PushAsync(new ProductsMangPage());
                    break;
                case "Persons managment":
                    await _navigation.PushAsync(new PersonsMangPage());
                    break;
                case "Add accessories":
                    await _navigation.PushAsync(new AddAccessoPage());
                    break;
                case "Create invoice":
                    await _navigation.PushAsync(new UpdatePersonPage(false,null,true));
                    break;
                case "About":
                    await _navigation.PushAsync(new AboutPage());
                    break;
                default:
                    break;
            }
        }
    }

    public class AdminOption
    {
        public string Option { get; set; }
    }

}
