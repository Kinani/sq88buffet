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
    public class MainPageViewModel
    {
        public INavigation _navigation;
        public ProductsCateg SelectedCatag { get; set; }
        public ObservableCollection<ProductsCateg> ProductsCateg { get; set; }
        public ICommand NavigateToPickerPageCommand { get; private set; }

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            ProductsCateg = new ObservableCollection<ProductsCateg>()
            {
                new ProductsCateg() {ProdType = "Drinks"},
                new ProductsCateg() {ProdType = "Sancks"},
                new ProductsCateg() {ProdType = "Food"},
                new ProductsCateg() {ProdType = "Admin" }
            };
            NavigateToPickerPageCommand = new Command(async () => await NavigateToPickerPage());
        }

        private async Task NavigateToPickerPage()
        {
            await _navigation.PushAsync(new PickProductPage(SelectedCatag));
        }
    }
    public class ProductsCateg
    {
        public string ProdType { get; set; }
    }
}
