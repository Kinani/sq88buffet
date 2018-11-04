using SQ88Buffet.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQ88Buffet.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteAsyncConnection sqliteconnection;
        public const string DbFileName = "buffetDB.db";

        public DatabaseHelper()
        {
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTableAsync<Person>().Wait();
            sqliteconnection.CreateTableAsync<Product>().Wait();
            sqliteconnection.CreateTableAsync<Purchase>().Wait();
        }
        #region Person CRUDS
        public Task<List<Person>> GetAllPersonsData()
        {
            //return (from data in sqliteconnection.Table<Person>() select data).ToList();
            return sqliteconnection.Table<Person>().ToListAsync();
        }

        public Task<List<Person>> GetAllPersonsData(string rank)
        {
            //return (from data in sqliteconnection.Table<Product>() select data).ToList();
            return sqliteconnection.Table<Person>().Where(x => x.Rank == rank).ToListAsync();
        }

        public Task<Person> GetPersonData(int id)
        {
            return sqliteconnection.Table<Person>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> DeleteAllPersons()
        {
            return sqliteconnection.DeleteAllAsync<Person>();
        }

        public Task<int> DeletePerson(int id)
        {
            return sqliteconnection.DeleteAsync<Person>(id);
        }

        public Task<int> InsertPerson(Person person)
        {
            return sqliteconnection.InsertAsync(person);
        }

        public Task<int> UpdatePerson(Person person)
        {
            return sqliteconnection.UpdateAsync(person);
        }
        #endregion

        #region Product CRUDS
        public Task<List<Product>> GetAllProductsData()
        {
            //return (from data in sqliteconnection.Table<Product>() select data).ToList();
            return sqliteconnection.Table<Product>().ToListAsync();
        }
        public Task<List<Product>> GetAllProductsData(string category)
        {
            //return (from data in sqliteconnection.Table<Product>() select data).ToList();
            return sqliteconnection.Table<Product>().Where(x => x.Category == category).ToListAsync();
        }

        public Task<Product> GetProductData(int id)
        {
            return sqliteconnection.Table<Product>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<int> DeleteAllProducts()
        {
            return sqliteconnection.DeleteAllAsync<Product>();
        }

        public Task<int> DeleteProduct(int id)
        {
            return sqliteconnection.DeleteAsync<Product>(id);
        }

        public Task<int> InsertProduct(Product product)
        {
            return sqliteconnection.InsertAsync(product);
        }

        public Task<int> UpdateProduct(Product product)
        {
            return sqliteconnection.UpdateAsync(product);
        }
        #endregion

        #region Purchase CRUDS
        public Task<List<Purchase>> GetAllPurchasesData()
        {
            //return (from data in sqliteconnection.Table<Purchase>() select data).ToList();
            return sqliteconnection.Table<Purchase>().ToListAsync();
        }

        public Task<Purchase> GetPurchaseData(int id)
        {
            return sqliteconnection.Table<Purchase>().FirstOrDefaultAsync(p => p.Id == id);
        }
        public Task<List<Purchase>> GetPurchasesDataForPerson(int personId)
        {
            return sqliteconnection.Table<Purchase>().Where(p => p.PersonId == personId).ToListAsync();
        }
        public Task<List<Purchase>> GetPurchasesDataForPersonWithDate(int personId, DateTime datetime)
        {
            return sqliteconnection.Table<Purchase>().Where(p => p.PersonId == personId 
            && p.PurchaseDate >= datetime).ToListAsync();
        }
        public Task<int> DeleteAllPurchases()
        {
            return sqliteconnection.DeleteAllAsync<Purchase>();
        }
        public Task<int> DeleteAllPurchasesForPerson(int personId)
        {
            return sqliteconnection.ExecuteAsync("DELETE FROM Purchase WHERE PersonId = ?", personId);
        }
        public Task<int> DeleteAllBilledPurchasesForPerson(int personId)
        {
            return sqliteconnection.ExecuteAsync("DELETE FROM Purchase WHERE PersonId = ? AND Billed = ?", personId, true);
        }
        public Task<int> DeletePurchase(int id)
        {
            return sqliteconnection.DeleteAsync<Purchase>(id);
        }

        public Task<int> InsertPurchase(Purchase purchase)
        {
            //purchase.PersonId = person.Id;
            //purchase.ProductId = product.Id;
            //purchase.PurchaseValue = purchase.UnitsOfProduct*product.Price; // Test for float point percision.
            return sqliteconnection.InsertAsync(purchase);
        }

        public Task<int> UpdatePurchase(Purchase purchase)
        {
            return sqliteconnection.UpdateAsync(purchase);
        }
        #endregion
    }
}
