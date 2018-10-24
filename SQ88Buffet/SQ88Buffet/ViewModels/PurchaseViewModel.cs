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
        public PurchaseViewModel()
        {
            
            _purchase = new Purchase();
            _purchase.UnitsOfProduct = 4;
            _purchaseRepository = new PurchaseRepository();


        }
    }
}
