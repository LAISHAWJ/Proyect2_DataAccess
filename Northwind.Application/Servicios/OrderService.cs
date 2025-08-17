using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using System;

namespace Northwind.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _repository.GetAllOrder();
        }

        public Order GetByIdOrder(int id)
        {
            return _repository.GetByIdOrder(id);
        }

        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _repository.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _repository.UpdateOrder(order);
        }

        public void DeleteOrder(int id)
        {
            var order = _repository.GetByIdOrder(id);
            if (order == null) throw new Exception("Orden no encontrada.");
            _repository.DeleteOrder(id);
        }

        public void DeleteOrderDetailAsync(int orderId, int productId)
        {
            var order = _repository.GetByIdOrder(orderId);
            if (order != null)
            {
                var detailToDelete = order.OrderDetails.FirstOrDefault(od => od.ProductId == productId);
                if (detailToDelete != null)
                {
                    _repository.DeleteOrderDetail(orderId, productId);
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailsForSelectionAsync()
        {
            return _repository.GetOrderDetailsForSelectionAsync();
        }

        public IEnumerable<Customer> GetCustomersAsync()
        {
            return _repository.GetCustomersAsync();
        }

        public IEnumerable<Employee> GetEmployeesAsync()
        {
            return _repository.GetEmployeesAsync();
        }

        public IEnumerable<Shipper> GetShippersAsync()
        {
            return _repository.GetShippersAsync();
        }

        public IEnumerable<Product> GetProductsAsync()
        {
            return _repository.GetProductsAsync();
        }

        public void AddOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            _repository.AddOrderDetailAsync(orderDetail);
        }

        public void UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            _repository.UpdateOrderDetailAsync(orderDetail);
        }
    }
}