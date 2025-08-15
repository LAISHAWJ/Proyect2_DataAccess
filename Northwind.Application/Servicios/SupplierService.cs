using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Servicios
{
    public class SupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            var supplier = await _repository.GetByIdAsync(id);
            if (supplier == null) throw new Exception("Suplidor no encontrado");
            return supplier;
        }

        public async Task AddAsync(Supplier supplier)
        {
            var validator = new SupplierValid();
            validator.ValidateAndThrow(supplier);
            await _repository.AddAsync(supplier);
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            var validator = new SupplierValid();
            validator.ValidateAndThrow(supplier);
            await _repository.UpdateAsync(supplier);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
