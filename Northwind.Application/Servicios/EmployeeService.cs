using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;

namespace Northwind.Application.Servicios
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _repository.GetAllEmployee();
        }

        public Employee GetByIdEmployee(int id)
        {
            var employee = _repository.GetByIdEmployee(id);
            if (employee == null) throw new Exception("Empleado no encontrado");
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            var validator = new EmployeeValid();
            validator.ValidateAndThrow(employee);
            _repository.AddEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var validator = new EmployeeValid();
            validator.ValidateAndThrow(employee);
            _repository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _repository.DeleteEmployee(id);
        }
    }
}