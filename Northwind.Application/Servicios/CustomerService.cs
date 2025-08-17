using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Collections.Generic;

namespace Northwind.Application.Servicios
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _repository.GetAllCustomer();
        }

        public Customer GetByIdCustomer(string id)
        {
            var customer = _repository.GetByIdCustomer(id);
            if (customer == null) throw new Exception("Cliente no encontrado");
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            var validator = new CustomerValid();
            validator.ValidateAndThrow(customer);
            _repository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var validator = new CustomerValid();
            validator.ValidateAndThrow(customer);
            _repository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(string id)
        {
            _repository.DeleteCustomer(id);
        }
    }
}