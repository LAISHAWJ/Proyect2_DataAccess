using Northwind.Core.Models;
using System.Collections.Generic;

namespace Northwind.Application.Interfaces
{
    public interface IOrderDetailsRepository
    {
        List<OrderWithDetailsViewModel> GetOrderWithDetailsAsync();
        List<OrderWithDetailsViewModel> GetOrderWithDetailsByOrderIdAsync(int orderId);
    }
}