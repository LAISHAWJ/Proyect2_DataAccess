using Northwind.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Text;
using Northwind.Core.Models;
using Northwind.Application.Validators;
using System.Threading.Tasks;


namespace Northwind.Application.Servicios
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("Categoría no encontrada");
            return category;
        }

        public async Task AddAsync(Category category)
        {
            var validator = new CategoryValid();
            validator.ValidateAndThrow(category); 
            await _repository.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            var validator = new CategoryValid();
            validator.ValidateAndThrow(category);
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

