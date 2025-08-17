using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;

namespace Northwind.Infrastructure.Repositories
{
    public class OrderDetailsRepos : IOrderDetailsRepository
    {
        private readonly NorthwindContext _context;

        public OrderDetailsRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<OrderWithDetailsViewModel> GetOrderWithDetailsAsync()
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .SelectMany(o => o.OrderDetails.Select(od => new OrderWithDetailsViewModel
                {
                    OrderId = o.OrderId,
                    CompanyName = o.Customer.CompanyName,
                    LastName = o.Employee.LastName,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    ShipViaName = o.ShipViaNavigation.CompanyName,
                    Freight = o.Freight,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipRegion = o.ShipRegion,
                    ShipPostalCode = o.ShipPostalCode,
                    ShipCountry = o.ShipCountry,
                    ProductName = od.Product.ProductName,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })).ToList();
        }

        public List<OrderWithDetailsViewModel> GetOrderWithDetailsByOrderIdAsync(int orderId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation)
                .Where(o => o.OrderId == orderId)
                .SelectMany(o => o.OrderDetails.Select(od => new OrderWithDetailsViewModel
                {
                    OrderId = o.OrderId,
                    CompanyName = o.Customer.CompanyName,
                    LastName = o.Employee.LastName,
                    OrderDate = o.OrderDate,
                    RequiredDate = o.RequiredDate,
                    ShippedDate = o.ShippedDate,
                    ShipViaName = o.ShipViaNavigation.CompanyName,
                    Freight = o.Freight,
                    ShipName = o.ShipName,
                    ShipAddress = o.ShipAddress,
                    ShipCity = o.ShipCity,
                    ShipRegion = o.ShipRegion,
                    ShipPostalCode = o.ShipPostalCode,
                    ShipCountry = o.ShipCountry,
                    ProductName = od.Product.ProductName,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                })).ToList();
        }
    }
}