using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Repositories
{
    public class OrderRepos : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Category)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                        .ThenInclude(p => p.Supplier)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task AddAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _context.Entry(order).State = EntityState.Modified;
            foreach (var item in order.OrderDetails)
            {
                _context.Entry(item).State = item.OrderId == 0 ? EntityState.Added : EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order != null)
            {
                _context.OrderDetails.RemoveRange(order.OrderDetails);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsForSelectionAsync()
        {
            return await _context.OrderDetails
                .Include(od => od.Product)
                    .ThenInclude(p => p.Category)
                .Include(od => od.Product)
                    .ThenInclude(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Shipper>> GetShippersAsync()
        {
            return await _context.Shippers.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task DeleteOrderDetail(int orderId, int productId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order != null)
            {
                var detailToDelete = order.OrderDetails.FirstOrDefault(od => od.ProductId == productId);
                if (detailToDelete != null)
                {
                    _context.OrderDetails.Remove(detailToDelete);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task AddOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == orderDetail.OrderId);
            if (order != null)
            {
                order.OrderDetails.Add(orderDetail);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Orden no encontrada para agregar el detalle.");
            }
        }

        public async Task UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            if (orderDetail == null) throw new ArgumentNullException(nameof(orderDetail));
            var existingDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(od => od.OrderId == orderDetail.OrderId && od.ProductId == orderDetail.ProductId);
            if (existingDetail != null)
            {
                _context.Entry(existingDetail).CurrentValues.SetValues(orderDetail);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Detalle de orden no encontrado para actualizar.");
            }
        }
    }
}