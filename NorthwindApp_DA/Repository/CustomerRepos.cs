using Microsoft.EntityFrameworkCore;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp_Final.Repository
{
    public class CustomerRepos
    {
        private readonly NorthwindContext _context;

        //CONSTRUCTOR
        public CustomerRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //OBTENER TODOS
        public List<Customer> GetAllCustomer()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }

        //AGREGAR
        public void AddCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        //ACTUALIZAR
        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //ELIMINAR
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
