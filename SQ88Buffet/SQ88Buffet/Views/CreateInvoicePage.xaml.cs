using SQ88Buffet.Models;
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
		public CreateInvoicePage (List<Person> people = null)
		{
			InitializeComponent ();
		}
	}
}