using SQ88Buffet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQ88Buffet.Services
{
    public interface IProductRepository
    {
        List<Product> GetAllProductData();
        Product GetProductData(int id);
        void DeleteAllProducts();
        void DeleteProduct(int id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
    }
}
