using Northwind.Application.Interfaces;
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
            await _repository.AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            await _repository.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) throw new Exception("Orden no encontrada.");
            await _repository.DeleteAsync(id);
        }

        public async Task DeleteOrderDetailAsync(int orderId, int productId)
        {
            var order = await _repository.GetByIdAsync(orderId);
            if (order != null)
            {
                var detailToDelete = order.OrderDetails.FirstOrDefault(od => od.ProductId == productId);
                if (detailToDelete != null)
                {
                    await _repository.DeleteOrderDetail(orderId, productId);
                }
            }
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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProductsAsync();
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            await _repository.AddOrderDetailAsync(orderDetail);
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            await _repository.UpdateOrderDetailAsync(orderDetail);
        }
    }
}