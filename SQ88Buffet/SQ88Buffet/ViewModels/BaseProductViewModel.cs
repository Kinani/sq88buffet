using SQ88Buffet.Models;
using SQ88Buffet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public string Name
        {
            get => _product.Name;
            set
            {
                _product.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public int Quantity
        {
            get => _product.Quantity;
            set
            {
                _product.Quantity = value;
                NotifyPropertyChanged("Quantity");
            }
        }

        public string Category
        {
            get => _product.Category;
            set
            {
                _product.Category = value;
                NotifyPropertyChanged("Category");
            }
        }


        public float Price
        {
            get => _product.Price;
            set
            {
                _product.Price = value;
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

        List<Product> _productsList;
        public List<Product> ProductsList
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
