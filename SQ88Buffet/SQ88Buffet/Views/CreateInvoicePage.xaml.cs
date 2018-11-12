using SQ88Buffet.Models;
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
	public partial class CreateInvoicePage : ContentPage
	{
        public CreateInvoicePageViewModel _CreateInvoicePageViewModel;
		public CreateInvoicePage (List<Person> people = null)
		{
			InitializeComponent ();
            _CreateInvoicePageViewModel = new CreateInvoicePageViewModel(Navigation,people);
            BindingContext = _CreateInvoicePageViewModel;

		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _CreateInvoicePageViewModel.GenerateReports();
        }
    }
}