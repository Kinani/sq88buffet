using SQ88Buffet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQ88Buffet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateProductPage : ContentPage
    {
        PickProductsViewModel _pickProductsViewModel;
        public UpdateProductPage()
        {
            InitializeComponent();
            _pickProductsViewModel = new PickProductsViewModel(Navigation);
            BindingContext = _pickProductsViewModel;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _pickProductsViewModel.FetchAllProducts();
        }
    }
}