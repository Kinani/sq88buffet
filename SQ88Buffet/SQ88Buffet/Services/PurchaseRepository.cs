using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQ88Buffet.Helpers;
using SQ88Buffet.Models;

namespace SQ88Buffet.Services
{
    public class PurchaseRepository : IPurchaseRepository
    {
        DatabaseHelper _databaseHelper;
        public PurchaseRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public async Task DeleteAllBilledPurchaseForPerson(int personId)
        {
            await _databaseHelper.DeleteAllBilledPurchasesForPerson(personId);
        }

        public async Task DeleteAllPurchases()
        {
            await _databaseHelper.DeleteAllPurchases();
        }

        public async Task DeleteAllPurchasesForPerson(int personId)
        {
            await _databaseHelper.DeleteAllPurchasesForPerson(personId);
        }

        public async Task DeletePurchase(int id)
        {
            await _databaseHelper.DeletePurchase(id);
        }

        public async Task<List<Purchase>> GetAllPurchaseData()
        {
            return await _databaseHelper.GetAllPurchasesData();
        }

        public async Task<Purchase> GetPurchaseData(int id)
        {
            return await _databaseHelper.GetPurchaseData(id);
        }

        public async Task<List<Purchase>> GetPurchasesDataForPerson(int personId)
        {
            return await _databaseHelper.GetPurchasesDataForPerson(personId);
        }

        public async Task<List<Purchase>> GetPurchasesDataForPersonWithDate(int personId, DateTime datetime)
        {
            return await _databaseHelper.GetPurchasesDataForPersonWithDate(personId, datetime);
        }

        public async Task InsertPurchase(Purchase purchase, Person person, Product product)
        {
            await _databaseHelper.InsertPurchase(purchase, person, product);
        }

        public async Task UpdatePurchase(Purchase purchase)
        {
            await _databaseHelper.UpdatePurchase(purchase);
        }
    }
}
