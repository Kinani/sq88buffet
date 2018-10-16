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
	public partial class AddEditPersonPage : ContentPage
	{
        public AddEditPersonViewModel _addEditPersonViewModel;
        public AddEditPersonPage (Person pers = null, bool delete = false)
		{
			InitializeComponent ();
            _addEditPersonViewModel = new AddEditPersonViewModel(Navigation, pers, delete);
            BindingContext = _addEditPersonViewModel;
            if (delete)
            {
                Title = "Delete person";
                SubmitButton.Text = "Delete Person";
            }
		}
	}
}