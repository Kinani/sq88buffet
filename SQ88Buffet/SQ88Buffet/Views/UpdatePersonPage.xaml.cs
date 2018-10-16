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
	public partial class UpdatePersonPage : ContentPage
	{
        PickPersonsViewModel _pickPersonsViewModel;

        public UpdatePersonPage ()
		{
			InitializeComponent ();
            _pickPersonsViewModel = new PickPersonsViewModel(Navigation);
            BindingContext = _pickPersonsViewModel;
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _pickPersonsViewModel.FetchAllPersons();
        }
    }
}