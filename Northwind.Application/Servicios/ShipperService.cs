using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;

namespace Northwind.Application.Servicios
{
    public class ShipperService
    {
        private readonly IShipperRepository _repository;

        public ShipperService(IShipperRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Shipper> GetAllShipper()
        {
            return _repository.GetAllShipper();
        }

        public Shipper GetByIdShipper(int id)
        {
            var shipper = _repository.GetByIdShipper(id);
            if (shipper == null) throw new Exception("Transportista no encontrado");
            return shipper;
        }

        public void AddShipper(Shipper shipper)
        {
            var validator = new ShipperValid();
            validator.ValidateAndThrow(shipper);
            _repository.AddShipper(shipper);
        }

        public void UpdateShipper(Shipper shipper)
        {
            var validator = new ShipperValid();
            validator.ValidateAndThrow(shipper);
            _repository.UpdateShipper(shipper);
        }

        public void DeleteShipper(int id)
        {
            _repository.DeleteShipper(id);
        }
    }
}