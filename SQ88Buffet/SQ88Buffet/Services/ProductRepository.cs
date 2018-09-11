using System;
using System.Collections.Generic;
using System.Text;
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
        public void DeleteAllProducts()
        {
            _databaseHelper.DeleteAllProducts();
        }

        public void DeleteProduct(int id)
        {
            _databaseHelper.DeleteProduct(id);
        }

        public List<Product> GetAllProductData()
        {
            return _databaseHelper.GetAllProductsData();
        }

        public Product GetProductData(int id)
        {
            return _databaseHelper.GetProductData(id);
        }

        public void InsertProduct(Product product)
        {
            _databaseHelper.InsertProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _databaseHelper.UpdateProduct(product);
        }
    }
}
