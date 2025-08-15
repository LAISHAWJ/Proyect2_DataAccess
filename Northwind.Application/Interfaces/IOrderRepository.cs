using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
        Task<IEnumerable<OrderDetail>> GetOrderDetailsForSelectionAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<IEnumerable<Shipper>> GetShippersAsync();
    }
}
