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
	
	public partial class AdminPage : ContentPage
	{
        public AdminPageViewModel _adminPageViewModel;
		public AdminPage ()
		{
			InitializeComponent ();
            _adminPageViewModel = new AdminPageViewModel(Navigation);
            BindingContext = _adminPageViewModel;
		}
	}
}