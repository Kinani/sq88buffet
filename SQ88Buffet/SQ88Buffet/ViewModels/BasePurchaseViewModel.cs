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
        public Purchase Purchase;
        public INavigation _navigation;
        public IPurchaseRepository _purchaseRepository;
        public IProductRepository _productRepository;


        public int PersonId
        {
            get => Purchase.PersonId;
            set
            {
                Purchase.PersonId = value;
                NotifyPropertyChanged("PersonId");
            }
        }

        public int ProductId
        {
            get => Purchase.ProductId;
            set
            {
                Purchase.ProductId = value;
                NotifyPropertyChanged("ProductId");
            }
        }
        public string ProductName
        {
            get => Purchase.ProductName == string.Empty ? null : Purchase.ProductName;
            set
            {
                Purchase.ProductName = value;
                NotifyPropertyChanged("ProductName");
            }
        }
        public string ProductCategory
        {
            get => Purchase.ProductCategory== string.Empty ? null : Purchase.ProductCategory;
            set
            {
                Purchase.ProductName = value;
                NotifyPropertyChanged("ProductCategory");
            }
        }
        public decimal ProductQuantity
        {
            get => int.TryParse(Purchase.ProductQuantity.ToString(), out quantityTemp) ? quantityTemp : 0;
            set
            {
                Purchase.ProductQuantity = int.TryParse(value.ToString(), out quantityTemp) ? quantityTemp : 0;
                NotifyPropertyChanged("ProductQuantity");
            }
        }

        public decimal ProductPrice
        {
            get => decimal.TryParse(Purchase.ProductPrice.ToString(), out priceTemp) ? priceTemp : 0;
            set
            {
                Purchase.ProductPrice = decimal.TryParse(value.ToString(), out priceTemp) ? priceTemp : 0;
                NotifyPropertyChanged("ProductPrice");
            }
        }
        public int UnitsOfProduct
        {
            get => int.TryParse(Purchase.UnitsOfProduct.ToString(), out unitsOfProductTemp) ? unitsOfProductTemp : 0;
            set
            {
                Purchase.UnitsOfProduct = int.TryParse(value.ToString(), out unitsOfProductTemp) ? unitsOfProductTemp : 0;
                NotifyPropertyChanged("UnitsOfProduct");
            }
        }
        
        public decimal PurchaseValue
        {
            get => decimal.TryParse(Purchase.PurchaseValue.ToString(), out purchaseValueTemp) ? purchaseValueTemp : 0;
            set
            {
                Purchase.PurchaseValue = decimal.TryParse(value.ToString(), out purchaseValueTemp) ? purchaseValueTemp : 0;
                NotifyPropertyChanged("PurchaseValue");
            }
        }

        public bool Billed
        {
            get => Purchase.Billed;
            set
            {
                Purchase.Billed = value;
                NotifyPropertyChanged("Billed");
            }
        }

        public bool IsCompleted
        {
            get => Purchase.IsCompleted;
            set
            {
                Purchase.IsCompleted = value;
                NotifyPropertyChanged("IsCompleted");
            }
        }

        public DateTime PurchaseDate
        {
            get => Purchase.PurchaseDate;
            set
            {
                Purchase.PurchaseDate = value;
                NotifyPropertyChanged("PurchaseDate");
            }
        }

        ObservableCollection<Purchase> _purchasesList;
        ObservableCollection<Purchase> _interiorPurchasesList;
        private decimal purchaseValueTemp;
        private int unitsOfProductTemp;
        private int quantityTemp;
        private decimal priceTemp;

        List<Product> _productList;

        public List<Product> ProductList
        {
            get => _productList;
            set
            {
                _productList = value;
                NotifyPropertyChanged("ProductList");
            }
        }


        ObservableCollection<Product> _foodList;

        public ObservableCollection<Product> FoodList
        {
            get => _foodList;
            set
            {
                _foodList = value;
                NotifyPropertyChanged("FoodList");
            }
        }
        ObservableCollection<Product> _snacksList;

        public ObservableCollection<Product> SnacksList
        {
            get => _snacksList;
            set
            {
                _snacksList = value;
                NotifyPropertyChanged("SnacksList");
            }
        }
        ObservableCollection<Product> _drinksList;
        private ObservableCollection<Purchase> _foodPurchasesList;
        private ObservableCollection<Purchase> _drinksPurchasesList;
        private ObservableCollection<Purchase> _snacksPurchasesList;

        public ObservableCollection<Product> DrinksList
        {
            get => _drinksList;
            set
            {
                _drinksList = value;
                NotifyPropertyChanged("DrinksList");
            }
        }

        public ObservableCollection<Purchase> PurchasesList
        {
            get => _purchasesList;
            set
            {
                _purchasesList = value;
                NotifyPropertyChanged("PurchasesList");
            }
        }
        public ObservableCollection<Purchase> FoodPurchasesList
        {
            get => _foodPurchasesList;
            set
            {
                _foodPurchasesList = value;
                NotifyPropertyChanged("FoodPurchasesList");
            }
        }
        public ObservableCollection<Purchase> DrinksPurchasesList
        {
            get => _drinksPurchasesList;
            set
            {
                _drinksPurchasesList = value;
                NotifyPropertyChanged("DrinksPurchasesList");
            }
        }
        public ObservableCollection<Purchase> SnacksPurchasesList
        {
            get => _snacksPurchasesList;
            set
            {
                _snacksPurchasesList = value;
                NotifyPropertyChanged("SnacksPurchasesList");
            }
        }
        public ObservableCollection<Purchase> InteriorPurchasesList
        {
            get => _interiorPurchasesList;
            set
            {
                _interiorPurchasesList = value;
                NotifyPropertyChanged("InteriorPurchasesList");
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
