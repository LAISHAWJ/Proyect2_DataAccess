using FluentValidation;
using Northwind.Core.Models;

namespace Northwind.Application.Validators
{
    public class CategoryValid : AbstractValidator<Category>
    {
        public CategoryValid()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("El nombre de la categoría es obligatorio.")
                .MaximumLength(15).WithMessage("El nombre de la categoría no debe exceder 15 caracteres.");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("La descripción de la categoría es obligatoria.")
                .Length(1, 100).WithMessage("La descripción de la categoría debe tener entre 1 y 100 caracteres.");
        }

    }
}
