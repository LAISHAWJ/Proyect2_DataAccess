using FluentValidation;
using NorthwindApp_DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp_Final.Validators
{
    public class ShipperValid : AbstractValidator<Shipper>
    {
        public ShipperValid()
        {

            RuleFor(e => e.CompanyName)
                .NotEmpty().WithMessage("El nombre de la compañía es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre de la compañía no debe exceder los 50 caracteres.");


            RuleFor(e => e.Phone)
               .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^\+?[\d\s\-\(\)]{7,20}$")
                .WithMessage("El teléfono debe contener solo números, espacios, guiones o paréntesis y tener entre 7 y 20 caracteres.");

        }
    }
}
