using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Application.Services
{
    public class OrderDetailsService
    {
        private readonly IOrderDetailsRepository _repository;

        public OrderDetailsService(IOrderDetailsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<OrderWithDetailsViewModel>> GetOrderWithDetailsAsync()
        {
            return await _repository.GetOrderWithDetailsAsync();
        }

        public async Task<List<OrderWithDetailsViewModel>> GetOrderWithDetailsByOrderIdAsync(int orderId)
        {
            return await _repository.GetOrderWithDetailsByOrderIdAsync(orderId);
        }
    }
}