using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var validator = new ProductValid(); 
            validator.ValidateAndThrow(product);
            await _repository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var validator = new ProductValid();
            validator.ValidateAndThrow(product);
            await _repository.UpdateAsync(product);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _repository.GetAllCategoriesAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _repository.GetAllSuppliersAsync();
        }
    }
}