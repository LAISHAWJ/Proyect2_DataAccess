using Northwind.Core.Models;
using System.Collections.Generic;

namespace Northwind.Application.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();
        Product GetByIdProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        IEnumerable<Category> GetAllCategoriesAsync();
        IEnumerable<Supplier> GetAllSuppliersAsync();
    }
}