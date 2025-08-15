using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            var validator = new OrderValid(); 
            validator.ValidateAndThrow(order);
            await _repository.AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            var validator = new OrderValid();
            validator.ValidateAndThrow(order);
            await _repository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new Exception("Orden no encontrada.");
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsForSelectionAsync()
        {
            return await _repository.GetOrderDetailsForSelectionAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _repository.GetCustomersAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _repository.GetEmployeesAsync();
        }

        public async Task<IEnumerable<Shipper>> GetShippersAsync()
        {
            return await _repository.GetShippersAsync();
        }
    }
}