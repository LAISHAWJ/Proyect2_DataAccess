using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Repositories
{
    public class EmployeeRepos : IEmployeeRepository
    {
        private readonly NorthwindContext _context;

        // Constructor
        public EmployeeRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Obtener todos
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        // Obtener por ID
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        // Agregar
        public async Task AddAsync(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        // Actualizar
        public async Task UpdateAsync(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Eliminar
        public async Task DeleteAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}