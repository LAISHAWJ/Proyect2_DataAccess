using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Infrastructure.Repositories
{
    public class ShipperRepos : IShipperRepository
    {
        private readonly NorthwindContext _context;

        // Constructor
        public ShipperRepos(NorthwindContext context)
        {
            _context = context;
        }

        // Obtener todos
        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            return await _context.Shippers.ToListAsync();
        }

        // Obtener por ID
        public async Task<Shipper?> GetByIdAsync(int id)
        {
            return await _context.Shippers.FindAsync(id);
        }

        // Agregar
        public async Task AddAsync(Shipper shipper)
        {
            if (shipper == null)
                throw new ArgumentNullException(nameof(shipper));
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();
        }

        // Actualizar
        public async Task UpdateAsync(Shipper shipper)
        {
            if (shipper == null)
                throw new ArgumentNullException(nameof(shipper));
            _context.Entry(shipper).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Eliminar
        public async Task DeleteAsync(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper != null)
            {
                _context.Shippers.Remove(shipper);
                await _context.SaveChangesAsync();
            }
        }
    }
}