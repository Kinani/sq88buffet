
using SQ88Buffet.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SQ88Buffet.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "buffetDB.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTable<Person>();
            sqliteconnection.CreateTable<Product>();
            sqliteconnection.CreateTable<Purchase>();
        }
        #region Person CRUDS
        public List<Person> GetAllPersonsData()
        {
            return (from data in sqliteconnection.Table<Person>() select data).ToList();
        }
        
        public Person GetPersonData(int id)
        {
            return sqliteconnection.Table<Person>().FirstOrDefault(p => p.Id == id);
        }

        public void DeleteAllPersons()
        {
            sqliteconnection.DeleteAll<Person>();
        }

        public void DeletePerson(int id)
        {
            sqliteconnection.Delete<Person>(id);
        }

        public void InsertPerson(Person person)
        {
            sqliteconnection.Insert(person);
        }

        public void UpdatePerson(Person person)
        {
            sqliteconnection.Update(person);
        }
        #endregion

        #region Product CRUDS
        public List<Product> GetAllProductData()
        {
            return (from data in sqliteconnection.Table<Product>() select data).ToList();
        }

        public Product GetProductData(int id)
        {
            return sqliteconnection.Table<Product>().FirstOrDefault(p => p.Id == id);
        }

        public void DeleteAllProducts()
        {
            sqliteconnection.DeleteAll<Product>();
        }

        public void DeleteProduct(int id)
        {
            sqliteconnection.Delete<Product>(id);
        }

        public void InsertProduct(Product product)
        {
            sqliteconnection.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            sqliteconnection.Update(product);
        }
        #endregion

        #region Purchase CRUDS
        public List<Purchase> GetAllPurchaseData()
        {
            return (from data in sqliteconnection.Table<Purchase>() select data).ToList();
        }

        public Purchase GetPurchaseData(int id)
        {
            return sqliteconnection.Table<Purchase>().FirstOrDefault(p => p.Id == id);
        }
        public List<Purchase> GetPurchaseDataForPerson(int personId)
        {
            return sqliteconnection.Table<Purchase>().Where(p => p.PersonId == personId).ToList();
        }
        public List<Purchase> GetPurchaseDataForPersonWithDate(int personId, DateTime datetime)
        {
            return sqliteconnection.Table<Purchase>().Where(p => p.PersonId == personId 
            && p.PurchaseDate >= datetime).ToList();
        }
        public void DeleteAllPurchases()
        {
            sqliteconnection.DeleteAll<Purchase>();
        }
        public void DeleteAllPurchasesForPerson(int personId)
        {
            sqliteconnection.Execute("DELETE FROM Purchase WHERE PersonId = ?", personId);
        }
        public void DeleteAllBilledPurchaseForPerson(int personId)
        {
            sqliteconnection.Execute("DELETE FROM Purchase WHERE PersonId = ? AND Billed = ?", personId, true);
        }
        public void DeletePurchase(int id)
        {
            sqliteconnection.Delete<Purchase>(id);
        }

        public void InsertPurchase(Purchase purchase, Person person, Product product)
        {
            purchase.PersonId = person.Id;
            purchase.ProductId = product.Id;
            purchase.PurchaseValue = purchase.UnitsOfProduct*product.Price; // Test for float point percision.
            sqliteconnection.Insert(purchase);
        }

        public void UpdatePurchase(Purchase purchase)
        {
            sqliteconnection.Update(purchase);
        }
        #endregion
    }
}
