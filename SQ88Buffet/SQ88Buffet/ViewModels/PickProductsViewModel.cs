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
    public class PickProductsViewModel : BaseProductViewModel
    {
        public ICommand ViewAllProductsCommand { get; private set; }
        public ICommand SaveAndProccedCommand { get; private set; }
        public ICommand AddPurchaseCommand { get; private set; }
        public ICommand DiscardAllCommand { get; private set; }
        public ICommand NavigateToUpdateProdPageCommand { get; private set; }
        public ICommand NavigateToDeleteProdPageCommand { get; private set; }

        bool viewWithCategory = false;

        public PickProductsViewModel(INavigation navigation, ProductsCateg category = null)
        {
            _navigation = navigation;
            _product = new Product();
            _productRepository = new ProductRepository();
            
            ProductsList = new ObservableCollection<Product>();
            if (category != null)
            {
                Category = category.ProdType;
                viewWithCategory = true;
            }

            ViewAllProductsCommand = new Command(async () => await ShowAllProducts(Category));
            SaveAndProccedCommand = new Command(async () => await SavePurchasesAndProcced());
            AddPurchaseCommand = new Command(async () => await AddPurchaseOrIncreaseQuantity());
            DiscardAllCommand = new Command(async () => await DiscardAll());

            NavigateToUpdateProdPageCommand = new Command(async (e) => await NavigateToUpdateProdPage(e));
            NavigateToDeleteProdPageCommand = new Command(async (e) => await NavigateToDeleteProdPage(e));

        }

        private async Task NavigateToDeleteProdPage(object e)
        {
            Product selectedProd = (e as Product);
            await _navigation.PushAsync(new AddEditProductPage(selectedProd,true));
        }

        private async Task NavigateToUpdateProdPage(object e)
        {
            Product selectedProd = (e as Product);
            await _navigation.PushAsync(new AddEditProductPage(selectedProd));
        }

        public async Task FetchAllProducts()
        {
            ProductsList = new ObservableCollection<Product>(await _productRepository.GetAllProductData());
        }
        public async Task FetchAllProductsWithCategory(string category)
        {
            ProductsList = new ObservableCollection<Product>(
                await _productRepository.GetAllProductData(category));
        }
        private async Task DiscardAll()
        {
            throw new NotImplementedException();
        }

        private async Task AddPurchaseOrIncreaseQuantity()
        {
            throw new NotImplementedException();
        }

        private async Task SavePurchasesAndProcced()
        {
            throw new NotImplementedException();
        }

        private async Task ShowAllProducts(string category)
        {
            if (category == string.Empty)
            {
                await FetchAllProducts();
            }
            else
            {
                await FetchAllProductsWithCategory(category);
            }
        }
    }
}
