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

        // Constructor
        public SupplierRepos(NorthwindContext context)
        {
            _context = context;
        }

        // Obtener todos
        public IEnumerable<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }

        // Obtener por ID
        public Supplier GetByIdSupplier(int id)
        {
            return _context.Suppliers.Find(id);
        }

        // Agregar
        public void AddSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        // Actualizar
        public void UpdateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Eliminar
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