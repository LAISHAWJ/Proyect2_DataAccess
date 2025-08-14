using FluentValidation;
using NorthwindApp_DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp_Final.Validators
{
    public class EmployeeValid : AbstractValidator<Employee>
    {
        public EmployeeValid() 
        {
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no debe exceder los 50 caracteres.");

           
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no debe exceder los 50 caracteres.");


            RuleFor(e => e.HomePhone)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^\+?[\d\s\-\(\)]{7,20}$")
                .WithMessage("El teléfono debe contener solo números, espacios, guiones o paréntesis y tener entre 7 y 20 caracteres.");


            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(100).WithMessage("La dirección no debe exceder los 100 caracteres.");

            RuleFor(e => e.Extension)
                .MaximumLength(4).WithMessage("Debe ser máximo 4 digitos");

            RuleFor(e => e.City)
               .NotEmpty().WithMessage("La ciudad es obligatoria.")
               .MaximumLength(50).WithMessage("La ciudad no debe exceder los 50 caracteres.");

            RuleFor(e => e.Country)
                .NotEmpty().WithMessage("El país es obligatorio.")
                .MaximumLength(50).WithMessage("El país no debe exceder los 50 caracteres.");


            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(50).WithMessage("El título no debe exceder los 50 caracteres.");

            
            RuleFor(e => e.HireDate)
                .NotNull().WithMessage("La fecha de contratación es obligatoria.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("La fecha de contratación no puede ser futura.");

        }


    }
    
}
