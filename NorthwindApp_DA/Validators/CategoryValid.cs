using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindApp_DA.Models;
using FluentValidation;

namespace NorthwindApp_DA.Validators
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
                .Length(1, 50).WithMessage("La descripción de la categoría debe tener entre 1 y 50 caracteres.");
        }

    }
}
