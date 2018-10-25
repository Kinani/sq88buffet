using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SQ88Buffet.ViewModels
{
    public class BaseProductViewModel : INotifyPropertyChanged
    {
        public Product _product;
        public INavigation _navigation;
        public IProductRepository _productRepository;


        decimal priceTemp;
        int quantityTemp;
        int unitsOfProductTemp;

        public string Name
        {
            get => _product.Name == string.Empty ? null : _product.Name;
            set
            {
                _product.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int UnitsOfProduct
        {
            get => int.TryParse(_product.UnitsOfProduct.ToString(), out unitsOfProductTemp) ? unitsOfProductTemp : 0;
            set
            {
                _product.UnitsOfProduct = int.TryParse(value.ToString(), out unitsOfProductTemp) ? unitsOfProductTemp : 0;
                NotifyPropertyChanged("UnitsOfProduct");
            }
        }
        public decimal Quantity
        {
            get => int.TryParse(_product.Quantity.ToString(), out quantityTemp) ? quantityTemp : 0;
            set
            {
                _product.Quantity = int.TryParse(value.ToString(), out quantityTemp) ? quantityTemp : 0;
                NotifyPropertyChanged("Quantity");
            }
        }

        public string Category
        {
            get => _product.Category == string.Empty ? null : _product.Category;
            set
            {
                _product.Category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public decimal Price
        {
            get => decimal.TryParse(_product.Price.ToString(), out priceTemp) ? priceTemp : 0;
            set
            {
                _product.Price = decimal.TryParse(value.ToString(), out priceTemp) ? priceTemp : 0;
                NotifyPropertyChanged("Price");
            }
        }


        public DateTime ExpiryDate
        {
            get => _product.ExpiryDate;
            set
            {
                _product.ExpiryDate = value;
                NotifyPropertyChanged("ExpiryDate");
            }
        }

        ObservableCollection<Product> _productsList;

        public ObservableCollection<Product> ProductsList
        {
            get => _productsList;
            set
            {
                _productsList = value;
                NotifyPropertyChanged("ProductsList");
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
