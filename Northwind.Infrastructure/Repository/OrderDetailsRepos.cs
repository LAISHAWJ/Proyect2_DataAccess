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
    public class OrderDetailsRepos
    {
        private readonly NorthwindContext _context;

        public OrderDetailsRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<OrderWithDetailsViewModel> GetOrderWithDetails()
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

        public List<OrderWithDetailsViewModel> GetOrderWithDetailsByOrderId(int orderId)
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

    // Vista modelo para combinar Order y OrderDetails
    public class OrderWithDetailsViewModel
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string LastName { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string ShipViaName { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}