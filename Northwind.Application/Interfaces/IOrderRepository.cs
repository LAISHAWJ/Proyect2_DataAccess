using Northwind.Core.Models;
using System.Collections.Generic;

namespace Northwind.Application.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();
        Order GetByIdOrder(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        IEnumerable<OrderDetail> GetOrderDetailsForSelectionAsync();
        IEnumerable<Customer> GetCustomersAsync();
        IEnumerable<Employee> GetEmployeesAsync();
        IEnumerable<Shipper> GetShippersAsync();
        IEnumerable<Product> GetProductsAsync();
        void DeleteOrderDetail(int orderId, int productId);
        void AddOrderDetailAsync(OrderDetail orderDetail);
        void UpdateOrderDetailAsync(OrderDetail orderDetail);
    }
}