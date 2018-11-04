using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace SQ88Buffet.Models
{
    [Table("Purchase")]
    public class Purchase : INotifyPropertyChanged
    {
        private int id;
        private int personId;
        private int productId;
        private decimal productQuantity;
        private string productName;
        private string productCategory;
        private decimal productPrice;
        private int unitsOfProduct;
        private decimal purchaseValue;
        private bool isCompleted;
        private bool billed;
        private DateTime purchaseDate;

        [DataMember]
        [PrimaryKey]
        [AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        [DataMember]
        public int PersonId
        {
            get { return personId; }
            set
            {
                personId = value;
                OnPropertyChanged("PersonId");
            }
        }
        [DataMember]
        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                OnPropertyChanged("ProductId");
            }
        }
        [DataMember]
        public decimal ProductQuantity
        {
            get { return productQuantity; }
            set
            {
                productQuantity = value;
                OnPropertyChanged("ProductQuantity");
            }
        }
        [DataMember]
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        [DataMember]
        public string ProductCategory
        {
            get { return productCategory; }
            set
            {
                productCategory = value;
                OnPropertyChanged("ProductCategory");
            }
        }
        [DataMember]
        public decimal ProductPrice
        {
            get { return productPrice; }
            set
            {
                productPrice = value;
                OnPropertyChanged("ProductPrice");
            }
        }
        [DataMember]
        public int UnitsOfProduct
        {
            get { return unitsOfProduct; }
            set
            {
                unitsOfProduct = value;
                OnPropertyChanged("UnitsOfProduct");
            }
        }
        [DataMember]
        public decimal PurchaseValue
        {
            get { return purchaseValue; }
            set
            {
                purchaseValue = value;
                OnPropertyChanged("PurchaseValue");
            }
        }
        [DataMember]
        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                isCompleted = value;
                OnPropertyChanged("IsCompleted");
            }
        }
        [DataMember]
        public bool Billed
        {
            get { return billed; }
            set
            {
                billed = value;
                OnPropertyChanged("Billed");
            }
        }
        [DataMember]
        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set
            {
                purchaseDate = value;
                OnPropertyChanged("PurchaseDate");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
