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
	public partial class ProductsMangPage : ContentPage
	{
        public ProductsMangViewModel _productsMangViewModel;
		public ProductsMangPage ()
		{
			InitializeComponent ();
            _productsMangViewModel = new ProductsMangViewModel(Navigation);
            BindingContext = _productsMangViewModel;
		}
	}
}