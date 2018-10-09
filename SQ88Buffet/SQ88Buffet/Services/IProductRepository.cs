using SQ88Buffet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQ88Buffet.Services
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductData();
        Task<List<Product>> GetAllProductData(string category);
        Task<Product> GetProductData(int id);
        Task DeleteAllProducts();
        Task DeleteProduct(int id);
        Task InsertProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
