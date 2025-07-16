using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NorthwindApp_DA.Models;

namespace NorthwindApp_DA.Validators
{
    public class ProductValid : AbstractValidator<Product>
    {
        public ProductValid()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre del producto no puede exceder 100 caracteres.");

            RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Debe seleccionar una categoría válida.");

            RuleFor(x => x.SupplierId)
               .GreaterThan(0).WithMessage("Debe seleccionar un suplidor válido.");

            RuleFor(p => p.QuantityPerUnit)
                .MaximumLength(50)
                .WithMessage("La cantidad por unidad no puede exceder 50 caracteres.");

            RuleFor(p => p.UnitPrice)
                .GreaterThanOrEqualTo(0).When(p => p.UnitPrice.HasValue)
                .WithMessage("El precio unitario debe ser mayor o igual a cero.");

            RuleFor(p => p.UnitsInStock)
                .GreaterThanOrEqualTo((short)0).When(p => p.UnitsInStock.HasValue)
                .WithMessage("Las unidades en stock deben ser mayor o igual a cero.");

            RuleFor(p => p.UnitsOnOrder)
                .GreaterThanOrEqualTo((short)0).When(p => p.UnitsOnOrder.HasValue)
                .WithMessage("Las unidades en orden deben ser mayor o igual a cero.");

            RuleFor(p => p.ReorderLevel)
                .GreaterThanOrEqualTo((short)0).When(p => p.ReorderLevel.HasValue)
                .WithMessage("El nivel de reorden debe ser mayor o igual a cero.");

        }
    }
}
