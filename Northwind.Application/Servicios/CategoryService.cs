using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using Northwind.Application.Validators;
using FluentValidation;
using System.Collections.Generic;

namespace Northwind.Application.Servicios
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _repository.GetAllCategory();
        }

        public Category GetByIdCategory(int id)
        {
            var category = _repository.GetByIdCategory(id);
            if (category == null) throw new Exception("Categoría no encontrada");
            return category;
        }

        public void AddCategory(Category category)
        {
            var validator = new CategoryValid();
            validator.ValidateAndThrow(category);
            _repository.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            var validator = new CategoryValid();
            validator.ValidateAndThrow(category);
            _repository.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _repository.DeleteCategory(id);
        }
    }
}