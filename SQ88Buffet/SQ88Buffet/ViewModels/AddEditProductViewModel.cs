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
    public class AddEditProductViewModel : BaseProductViewModel
    {
        public ICommand AddProductCommand { get; private set; }

        bool updateFlag;
        bool deleteFlag;
        public AddEditProductViewModel(INavigation navigation, Product productToUpdate = null, bool delete = false)
        {
            _navigation = navigation;
            updateFlag = false;

            deleteFlag = delete;

            if (productToUpdate == null)
                _product = new Product();
            else
            {
                _product = productToUpdate;
                updateFlag = true;
            }


            _productRepository = new ProductRepository();

            if (deleteFlag == false)
                AddProductCommand = new Command(async () => await AddProduct());
            else
                AddProductCommand = new Command(async () => await DeleteProduct());

        }

        private async Task AddProduct()
        {
            if (!updateFlag)
                await _productRepository.InsertProduct(_product);
            else
                await _productRepository.UpdateProduct(_product);
            await _navigation.PopAsync();
        }

        private async Task DeleteProduct()
        {
            if (deleteFlag)
                await _productRepository.DeleteProduct(_product.Id);

            await _navigation.PopAsync();
        }
    }
}
