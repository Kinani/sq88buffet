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
    public class PickProductsViewModel : BaseProductViewModel
    {
        public ICommand ViewAllProductsCommand { get; private set; }
        public ICommand SaveAndProccedCommand { get; private set; }
        public ICommand AddPurchaseCommand { get; private set; }
        public ICommand DiscardAllCommand { get; private set; }


        public PickProductsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _product = new Product();
            _productRepository = new ProductRepository();
            
            ProductsList = new List<Product>();
            Category = "Drinks";

            ViewAllProductsCommand = new Command(async () => await ShowAllProducts(Category));
            SaveAndProccedCommand = new Command(async () => await SavePurchasesAndProcced());
            AddPurchaseCommand = new Command(async () => await AddPurchaseOrIncreaseQuantity());
            DiscardAllCommand = new Command(async () => await DiscardAll());
        }

        private Task DiscardAll()
        {
            throw new NotImplementedException();
        }

        private Task AddPurchaseOrIncreaseQuantity()
        {
            throw new NotImplementedException();
        }

        private Task SavePurchasesAndProcced()
        {
            throw new NotImplementedException();
        }

        private Task ShowAllProducts(string category)
        {
            throw new NotImplementedException();
        }
    }
}
