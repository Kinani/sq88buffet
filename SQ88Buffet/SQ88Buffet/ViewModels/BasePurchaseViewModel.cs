using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class BasePurchaseViewModel : INotifyPropertyChanged
    {
        public Purchase _purchase;
        public INavigation _navigation;
        public IPurchaseRepository _purchaseRepository;

        public int PersonId
        {
            get => _purchase.PersonId;
            set
            {
                _purchase.PersonId = value;
                NotifyPropertyChanged("PersonId");
            }
        }

        public int ProductId
        {
            get => _purchase.ProductId;
            set
            {
                _purchase.ProductId = value;
                NotifyPropertyChanged("ProductId");
            }
        }

        public int UnitsOfProduct
        {
            get => int.TryParse(_purchase.UnitsOfProduct.ToString(), out unitsOfProductTemp) ? unitsOfProductTemp : 0;
            set
            {
                _purchase.UnitsOfProduct = int.TryParse(value.ToString(), out unitsOfProductTemp) ? unitsOfProductTemp : 0;
                NotifyPropertyChanged("UnitsOfProduct");
            }
        }
        
        public decimal PurchaseValue
        {
            get => decimal.TryParse(_purchase.PurchaseValue.ToString(), out purchaseValueTemp) ? purchaseValueTemp : 0;
            set
            {
                _purchase.PurchaseValue = decimal.TryParse(value.ToString(), out purchaseValueTemp) ? purchaseValueTemp : 0;
                NotifyPropertyChanged("PurchaseValue");
            }
        }

        public bool Billed
        {
            get => _purchase.Billed;
            set
            {
                _purchase.Billed = value;
                NotifyPropertyChanged("Billed");
            }
        }

        public DateTime PurchaseDate
        {
            get => _purchase.PurchaseDate;
            set
            {
                _purchase.PurchaseDate = value;
                NotifyPropertyChanged("PurchaseDate");
            }
        }

        ObservableCollection<Purchase> _purchasesList;
        private decimal purchaseValueTemp;
        private int unitsOfProductTemp;

        public ObservableCollection<Purchase> PurchasesList
        {
            get => _purchasesList;
            set
            {
                _purchasesList = value;
                NotifyPropertyChanged("PurchasesList");
            }
        }
        #region INotifyPropertyChanged      
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
