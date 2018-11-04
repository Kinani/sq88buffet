using SQ88Buffet.Models;
using SQ88Buffet.Services;
using SQ88Buffet.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class PurchaseCompletePageViewModel
    {
        public ICommand GoMainPage { get; private set; }

        public INavigation _navigation;
        public PurchaseRepository PurchaseRepo;
        public List<Purchase> FinalPurchases;

        public PurchaseCompletePageViewModel(INavigation navigation, List<Purchase> purchases)
        {
            _navigation = navigation;
            PurchaseRepo = new PurchaseRepository();
            FinalPurchases = new List<Purchase>();

            if (purchases != null)
                FinalPurchases = purchases;

            GoMainPage = new Command(async () => await NavigateToMainPage());
        }

        private async Task NavigateToMainPage()
        {
            await _navigation.PushAsync(new MainPage());
        }

        public async Task SavePurchasesToDb()
        {
            foreach (var item in FinalPurchases)
            {
                item.IsCompleted = true;
                await PurchaseRepo.InsertPurchase(item);
            }
        }
    }
}
