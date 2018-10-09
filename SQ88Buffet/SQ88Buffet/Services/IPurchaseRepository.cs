using SQ88Buffet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQ88Buffet.Services
{
    public interface IPurchaseRepository
    {
        Task<List<Purchase>> GetAllPurchaseData();
        Task<Purchase> GetPurchaseData(int id);
        Task<List<Purchase>> GetPurchasesDataForPerson(int personId);
        Task<List<Purchase>> GetPurchasesDataForPersonWithDate(int personId, DateTime datetime);
        Task DeleteAllPurchases();
        Task DeleteAllPurchasesForPerson(int personId);
        Task DeleteAllBilledPurchaseForPerson(int personId);
        Task DeletePurchase(int id);
        Task InsertPurchase(Purchase purchase, Person person, Product product);
        Task UpdatePurchase(Purchase purchase);
    }
}
