using FluentValidation;
using Northwind.Application.Interfaces;
using Northwind.Application.Validators;
using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Servicios
{
    public class ShipperService
    {
        private readonly IShipperRepository _repository;

        public ShipperService(IShipperRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Shipper> GetByIdAsync(int id)
        {
            var shipper = await _repository.GetByIdAsync(id);
            if (shipper == null) throw new Exception("Transportista no encontrado");
            return shipper;
        }

        public async Task AddAsync(Shipper shipper)
        {
            var validator = new ShipperValid();
            validator.ValidateAndThrow(shipper);
            await _repository.AddAsync(shipper);
        }

        public async Task UpdateAsync(Shipper shipper)
        {
            var validator = new ShipperValid();
            validator.ValidateAndThrow(shipper);
            await _repository.UpdateAsync(shipper);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
