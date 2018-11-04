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
    public partial class PurchaseComplete : ContentPage
    {
        public PurchaseCompletePageViewModel PurCompVM;
        public PurchaseComplete(List<Purchase> purchases)
        {
            InitializeComponent();
            PurCompVM = new PurchaseCompletePageViewModel(Navigation, purchases);
            BindingContext = PurCompVM;
        }
        protected async override void OnAppearing()
        {
            await PurCompVM.SavePurchasesToDb();
        }
    }
}