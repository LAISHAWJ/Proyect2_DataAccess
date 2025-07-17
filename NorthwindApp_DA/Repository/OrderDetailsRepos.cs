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

        public List<OrderDetail> GetAllOrderDetail()
        {
            return _context.OrderDetails.ToList();

        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails
            .Where(od => od.OrderId == orderId)
            .ToList();
        }



    }
}
