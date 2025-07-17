using Microsoft.EntityFrameworkCore;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp_DA.Repository
{
    internal class OrderRepos
    {
        private readonly NorthwindContext _context;
        public OrderRepos(NorthwindContext context)
        {
            _context = context;
        }
        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .ToList();
        }

        public Order? GetOrderById(int id)
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
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
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


        public List<OrderDetail> GetOrderDetailsForSelection()
        {
            return _context.OrderDetails
                .Include(od => od.Product)
                .ThenInclude(p => p.Category)
                .Include(od => od.Product)
                .ThenInclude(p => p.Supplier)
                .ToList();
        }



        public List<Customer> GetCustomers() => _context.Customers.ToList();
        public List<Employee> GetEmployees() => _context.Employees.ToList();
        public List<Shipper> GetShippers() => _context.Shippers.ToList();

}   }
