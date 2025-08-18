using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;

namespace Northwind.Infrastructure.Repositories
{
    public class ProductRepos : IProductRepository
    {
        private readonly NorthwindContext _context;

        
        public ProductRepos(NorthwindContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Product> GetAllProduct()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList();
        }

        
        public Product GetByIdProduct(int id)
        {
            return _context.Products.Find(id);
        }

        
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        
        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
        public IEnumerable<Category> GetAllCategoriesAsync()
        {
            return _context.Categories.OrderBy(c => c.CategoryName).ToList();
        }

        
        public IEnumerable<Supplier> GetAllSuppliersAsync()
        {
            return _context.Suppliers.OrderBy(s => s.CompanyName).ToList();
        }
    }
}