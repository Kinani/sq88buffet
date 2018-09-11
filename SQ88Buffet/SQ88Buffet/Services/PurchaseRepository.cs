using System;
using System.Collections.Generic;
using System.Text;
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
        public void DeleteAllBilledPurchaseForPerson(int personId)
        {
            _databaseHelper.DeleteAllBilledPurchasesForPerson(personId);
        }

        public void DeleteAllPurchases()
        {
            _databaseHelper.DeleteAllPurchases();
        }

        public void DeleteAllPurchasesForPerson(int personId)
        {
            _databaseHelper.DeleteAllPurchasesForPerson(personId);
        }

        public void DeletePurchase(int id)
        {
            _databaseHelper.DeletePurchase(id);
        }

        public List<Purchase> GetAllPurchaseData()
        {
            return _databaseHelper.GetAllPurchasesData();
        }

        public Purchase GetPurchaseData(int id)
        {
            return _databaseHelper.GetPurchaseData(id);
        }

        public List<Purchase> GetPurchasesDataForPerson(int personId)
        {
            return _databaseHelper.GetPurchasesDataForPerson(personId);
        }

        public List<Purchase> GetPurchasesDataForPersonWithDate(int personId, DateTime datetime)
        {
            return _databaseHelper.GetPurchasesDataForPersonWithDate(personId, datetime);
        }

        public void InsertPurchase(Purchase purchase, Person person, Product product)
        {
            _databaseHelper.InsertPurchase(purchase, person, product);
        }

        public void UpdatePurchase(Purchase purchase)
        {
            _databaseHelper.UpdatePurchase(purchase);
        }
    }
}
