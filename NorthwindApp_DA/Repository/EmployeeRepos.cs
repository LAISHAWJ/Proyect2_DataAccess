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
    public class EmployeeRepos
    {
        private readonly NorthwindContext _context;

        //CONSTRUCTOR
        public EmployeeRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //OBTENER TODOS
        public List<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        //AGREGAR
        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        //ACTUALIZAR
        public void UpdateEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //ELIMINAR
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }


    }
}
