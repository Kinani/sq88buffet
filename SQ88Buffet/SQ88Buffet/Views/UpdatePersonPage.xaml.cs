using SQ88Buffet.Models;
using SQ88Buffet.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQ88Buffet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UpdatePersonPage : ContentPage
	{
        PickPersonsViewModel _pickPersonsViewModel;
        bool _invoiceOn;
        public UpdatePersonPage (bool burchaseOn = false, List<Purchase> purchases = null, bool invoiceOn = false)
		{
			InitializeComponent ();
            _pickPersonsViewModel = new PickPersonsViewModel(Navigation, burchaseOn, purchases, invoiceOn);
            BindingContext = _pickPersonsViewModel;
            _invoiceOn = invoiceOn;
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _pickPersonsViewModel.FetchAllPersons();

            if(!_invoiceOn)
            {
                BtnAll.IsVisible = false;
            }
        }
    }
}