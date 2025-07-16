using Microsoft.EntityFrameworkCore;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;

namespace NorthwindApp_DA.Repository
{
    public class SupplierRepos
    {
        private readonly NorthwindContext _context;

        //CONSTRUCTOR
        public SupplierRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //OBTENER TODOS
        public List<Supplier> GetAllSupplier()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier? GeSupplierById(int id)
        {
            return _context.Suppliers.Find(id);
        }

        //AGREGAR
        public void AddSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        //ACTUALIZAR
        public void UpdateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            _context.Entry(supplier).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //ELIMINAR
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
