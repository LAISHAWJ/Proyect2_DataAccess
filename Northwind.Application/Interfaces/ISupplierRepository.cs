using Northwind.Core.Models;
using System.Collections.Generic;

namespace Northwind.Application.Interfaces
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetAllSupplier();
        Supplier GetByIdSupplier(int id);
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int id);
    }
}