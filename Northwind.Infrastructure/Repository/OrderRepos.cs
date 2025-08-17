using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;

namespace Northwind.Infrastructure.Repositories
{
    public class OrderRepos : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .ToList();
        }

        public Order GetByIdOrder(int id)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Category)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Supplier)
                .FirstOrDefault(o => o.OrderId == id);
        }

        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Entry(order).State = EntityState.Modified;
            foreach (var item in order.OrderDetails)
            {
                _context.Entry(item).State = item.OrderId == 0 ? EntityState.Added : EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == id);

            if (order != null)
            {
                _context.OrderDetails.RemoveRange(order.OrderDetails);
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetailsForSelectionAsync()
        {
            return _context.OrderDetails
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .Include(od => od.Product)
                    .ThenInclude(p => p.Supplier)
                .ToList();
        }

        public IEnumerable<Customer> GetCustomersAsync()
        {
            return _context.Customers.ToList();
        }

        public IEnumerable<Employee> GetEmployeesAsync()
        {
            return _context.Employees.ToList();
        }

        public IEnumerable<Shipper> GetShippersAsync()
        {
            return _context.Shippers.ToList();
        }

        public IEnumerable<Product> GetProductsAsync()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList();
        }

        public void DeleteOrderDetail(int orderId, int productId)
        {
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                var detailToDelete = order.OrderDetails.FirstOrDefault(od => od.ProductId == productId);
                if (detailToDelete != null)
                {
                    _context.OrderDetails.Remove(detailToDelete);
                    _context.SaveChanges();
                }
            }
        }

        public void AddOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == orderDetail.OrderId);
            if (order != null)
            {
                order.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Orden no encontrada para agregar el detalle.");
            }
        }

        public void UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            var existingDetail = _context.OrderDetails
                .FirstOrDefault(od => od.OrderId == orderDetail.OrderId && od.ProductId == orderDetail.ProductId);
            if (existingDetail != null)
            {
                _context.Entry(existingDetail).CurrentValues.SetValues(orderDetail);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Detalle de orden no encontrado para actualizar.");
            }
        }
    }
}