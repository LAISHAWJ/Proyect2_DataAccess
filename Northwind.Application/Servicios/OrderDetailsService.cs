using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using System;

namespace Northwind.Application.Services
{
    public class OrderDetailsService
    {
        private readonly IOrderDetailsRepository _repository;

        public OrderDetailsService(IOrderDetailsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<OrderWithDetailsViewModel> GetOrderWithDetailsAsync()
        {
            return _repository.GetOrderWithDetailsAsync();
        }

        public List<OrderWithDetailsViewModel> GetOrderWithDetailsByOrderIdAsync(int orderId)
        {
            return _repository.GetOrderWithDetailsByOrderIdAsync(orderId);
        }
    }
}