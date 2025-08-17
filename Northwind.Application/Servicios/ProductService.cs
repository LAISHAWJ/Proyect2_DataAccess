using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;

namespace Northwind.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _repository.GetAllProduct();
        }

        public Product GetByIdProduct(int id)
        {
            return _repository.GetByIdProduct(id);
        }

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var validator = new ProductValid();
            validator.ValidateAndThrow(product);
            _repository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var validator = new ProductValid();
            validator.ValidateAndThrow(product);
            _repository.UpdateProduct(product);
        }

        public IEnumerable<Category> GetAllCategoriesAsync()
        {
            return _repository.GetAllCategoriesAsync();
        }

        public IEnumerable<Supplier> GetAllSuppliersAsync()
        {
            return _repository.GetAllSuppliersAsync();
        }
    }
}