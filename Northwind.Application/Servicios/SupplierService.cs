using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;

namespace Northwind.Application.Servicios
{
    public class SupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Supplier> GetAllSupplier()
        {
            return _repository.GetAllSupplier();
        }

        public Supplier GetByIdSupplier(int id)
        {
            var supplier = _repository.GetByIdSupplier(id);
            if (supplier == null) throw new Exception("Suplidor no encontrado");
            return supplier;
        }

        public void AddSupplier(Supplier supplier)
        {
            var validator = new SupplierValid();
            validator.ValidateAndThrow(supplier);
            _repository.AddSupplier(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var validator = new SupplierValid();
            validator.ValidateAndThrow(supplier);
            _repository.UpdateSupplier(supplier);
        }

        public void DeleteSupplier(int id)
        {
            _repository.DeleteSupplier(id);
        }
    }
}