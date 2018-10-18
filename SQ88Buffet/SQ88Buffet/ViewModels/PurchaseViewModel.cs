using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class PurchaseViewModel : BasePurchaseViewModel
    {
        public PurchaseViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _purchase = new Purchase();
            _purchaseRepository = new PurchaseRepository();


        }
    }
}
