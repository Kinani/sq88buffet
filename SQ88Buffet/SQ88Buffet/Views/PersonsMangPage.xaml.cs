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
	public partial class PersonsMangPage : ContentPage
	{
        public PersonsMangViewModel _personsMangViewModel;

		public PersonsMangPage ()
		{
            InitializeComponent();
            _personsMangViewModel = new PersonsMangViewModel(Navigation);
            BindingContext = _personsMangViewModel;
		}
	}
}