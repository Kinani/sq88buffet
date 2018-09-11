using SQ88Buffet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQ88Buffet.Services
{
    public interface IPurchaseRepository
    {
        List<Purchase> GetAllPurchaseData();
        Purchase GetPurchaseData(int id);
        List<Purchase> GetPurchaseDataForPerson(int personId);
        List<Purchase> GetPurchaseDataForPersonWithDate(int personId, DateTime datetime);
        void DeleteAllPurchases();
        void DeleteAllPurchasesForPerson(int personId);
        void DeleteAllBilledPurchaseForPerson(int personId);
        void DeletePurchase(int id);
        void InsertPurchase(Purchase purchase, Person person, Product product);
        void UpdatePurchase(Purchase purchase);
    }
}
