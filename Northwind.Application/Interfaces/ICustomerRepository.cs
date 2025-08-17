using Northwind.Core.Models;
using System.Collections.Generic;

namespace Northwind.Application.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetByIdCustomer(string id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}