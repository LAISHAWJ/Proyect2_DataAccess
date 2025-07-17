using NorthwindApp_DA.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp_DA.Validators
{
    public class OrderValid : AbstractValidator<Order>
    {
        public OrderValid()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Seleccione un cliente.");
            RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("Seleccione un empleado.");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("Fecha de orden requerida.");
            RuleFor(x => x.RequiredDate).NotEmpty().WithMessage("Fecha requerida obligatoria.");
            RuleFor(x => x.ShipVia).NotEmpty().WithMessage("Seleccione un transportista.");
            RuleFor(x => x.ShipName).NotEmpty().WithMessage("Nombre del destinatario obligatorio.");
            RuleFor(x => x.ShipAddress).NotEmpty().WithMessage("Dirección obligatoria.");
        }
    }
}
