using Northwind.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Application.Interfaces
{
    public interface IOrderDetailsRepository
    {
        Task<List<OrderWithDetailsViewModel>> GetOrderWithDetailsAsync();
        Task<List<OrderWithDetailsViewModel>> GetOrderWithDetailsByOrderIdAsync(int orderId);
    }
}