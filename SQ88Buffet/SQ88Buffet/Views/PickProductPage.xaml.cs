using SQ88Buffet.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQ88Buffet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickProductPage : ContentPage
	{
        //public PickProductsViewModel _PickProductsViewModel { get; set; }
        public PurchaseViewModel PurchaseViewModel { get; set; }
        public ProductsCateg _ProductCategory { get; set; }
        public PickProductPage(ProductsCateg ProductsCategory)
		{
			InitializeComponent ();
            //_PickProductsViewModel = new PickProductsViewModel(Navigation, ProductsCategory);
            PurchaseViewModel = new PurchaseViewModel(Navigation, ProductsCategory);
            BindingContext = PurchaseViewModel;
            _ProductCategory = ProductsCategory;
            Debug.WriteLine(_ProductCategory.ProdType);
        }

        protected async override void OnAppearing()
        {
            //base.OnAppearing();
            //if (PurchaseViewModel.Category != string.Empty)
            //    await PurchaseViewModel.FetchAllProductsWithCategory(PurchaseViewModel.Category);
            //else
            //    await PurchaseViewModel.FetchAllProducts();
            await PurchaseViewModel.PopulatePurchases();
        }
    }
}