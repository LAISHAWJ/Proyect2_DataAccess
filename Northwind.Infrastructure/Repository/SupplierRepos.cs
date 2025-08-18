using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;

namespace Northwind.Infrastructure.Repositories
{
    public class SupplierRepos : ISupplierRepository
    {
        private readonly NorthwindContext _context;

        
        public SupplierRepos(NorthwindContext context)
        {
            _context = context;
        }

       
        public IEnumerable<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }

        
        public Supplier GetByIdSupplier(int id)
        {
            return _context.Suppliers.Find(id);
        }

        
        public void AddSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        
        public void UpdateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
        }

       
        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
    }
}