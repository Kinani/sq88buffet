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
    public class ProductsMangViewModel
    {
        public INavigation _navigation;


        public ObservableCollection<ProductOption> ProductOptions { get; set; }
        public ICommand NavigateToProductPageCommand { get; private set; }

        public ProductsMangViewModel(INavigation navigation)
        {
            _navigation = navigation;
            ProductOptions = new ObservableCollection<ProductOption>()
            {
                new ProductOption() { Option = "Add product"},
                new ProductOption() { Option = "Update product"},
                new ProductOption() { Option = "Delete product"}
            };
            NavigateToProductPageCommand = new Command(async (e) => await NavigateToProductPage(e));
        }

        private async Task NavigateToProductPage(object e)
        {
            var pickedOption = (e as ProductOption);
            switch (pickedOption.Option)
            {
                case "Add product":
                    await _navigation.PushAsync(new AddEditProductPage());
                    break;
                case "Update product":
                    await _navigation.PushAsync(new UpdateProductPage());
                    break;
                case "Delete product":
                    await _navigation.PushAsync(new DeleteProductPage());
                    break;
                default:
                    break;
            }
        }
    }

    public class ProductOption
    {
        public string Option { get; set; }
    }
}
