using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQ88Buffet.Helpers;
using SQ88Buffet.Models;

namespace SQ88Buffet.Services
{
    public class ProductRepository : IProductRepository
    {
        DatabaseHelper _databaseHelper;
        public ProductRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public async Task DeleteAllProducts()
        {
            await _databaseHelper.DeleteAllProducts();
        }

        public async Task DeleteProduct(int id)
        {
             await _databaseHelper.DeleteProduct(id);
        }

        public async Task<List<Product>> GetAllProductData()
        {
            return await _databaseHelper.GetAllProductsData();
        }

        public async Task<List<Product>> GetAllProductData(string category)
        {
            return await _databaseHelper.GetAllProductsData(category);
        }

        public async Task<Product> GetProductData(int id)
        {
            return await _databaseHelper.GetProductData(id);
        }

        public async Task InsertProduct(Product product)
        {
            await _databaseHelper.InsertProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _databaseHelper.UpdateProduct(product);
        }
    }
}
