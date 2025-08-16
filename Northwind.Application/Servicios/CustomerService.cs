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
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            var customer = await _repository.GetByIdAsync(id);
            if (customer == null) throw new Exception("Cliente no encontrado");
            return customer;
        }

        public async Task AddAsync(Customer customer)
        {
            var validator = new CustomerValid();
            validator.ValidateAndThrow(customer); 
            await _repository.AddAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            var validator = new CustomerValid();
            validator.ValidateAndThrow(customer);
            await _repository.UpdateAsync(customer);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

    }
}
