using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Servicios
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) throw new Exception("Empleado no encontrado");
            return employee;
        }

        public async Task AddAsync(Employee employee)
        {
            var validator = new EmployeeValid();
            validator.ValidateAndThrow(employee);
            await _repository.AddAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var validator = new EmployeeValid();
            validator.ValidateAndThrow(employee);
            await _repository.UpdateAsync(employee);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
