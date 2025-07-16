using FluentValidation;
using NorthwindApp_DA.Models;
using System.Text.RegularExpressions;

namespace NorthwindApp_DA.Validators
{
    public class SupplierValid : AbstractValidator<Supplier>
    {
        public SupplierValid()
        {
            RuleFor(s => s.CompanyName)
                .NotEmpty().WithMessage("El nombre de la compañía es obligatorio.")
                .MaximumLength(40).WithMessage("Máximo 40 caracteres para el nombre de la compañía.");

            RuleFor(s => s.ContactName)
                .NotEmpty().WithMessage("El nombre de contacto es obligatorio.")
                .MaximumLength(30).WithMessage("Máximo 30 caracteres para el nombre de contacto.");

            RuleFor(s => s.ContactTitle)
                .MaximumLength(30).WithMessage("Máximo 30 caracteres para el título de contacto.");

            RuleFor(s => s.Address)
                .NotEmpty().WithMessage("La dirección es obligatoria.")
                .MaximumLength(60).WithMessage("Máximo 60 caracteres para la dirección.");

            RuleFor(s => s.City)
                .MaximumLength(30).WithMessage("Máximo 30 caracteres para la ciudad.");

            RuleFor(s => s.Region)
                .MaximumLength(30).WithMessage("Máximo 30 caracteres para la región.");

            RuleFor(s => s.PostalCode)
                .MaximumLength(10).WithMessage("Máximo 10 caracteres para el código postal.");

            RuleFor(s => s.Country)
                .MaximumLength(50).WithMessage("Máximo 50 caracteres para el país.");

            RuleFor(s => s.Phone)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .Matches(@"^(\+?\d{1,3}[- ]?)?(\d{3}[- ]?\d{3}[- ]?\d{4})$")
                .WithMessage("El teléfono debe tener un formato válido")
                .MaximumLength(24).WithMessage("Máximo 24 caracteres para el teléfono.");

            RuleFor(s => s.Fax)
                .MaximumLength(24).WithMessage("Máximo 24 caracteres para el fax.");

            RuleFor(s => s.HomePage)
                .Must(BeValidUrl).WithMessage("El sitio web debe tener un formato válido.")
                .MaximumLength(200).WithMessage("Máximo 200 caracteres para la página web.")
                .When(x => !string.IsNullOrWhiteSpace(x.HomePage));
        }


        private bool BeValidUrl(string url)
        {
            return Regex.IsMatch(url, @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$");
        }
    }
}
