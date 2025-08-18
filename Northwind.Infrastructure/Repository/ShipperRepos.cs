using Microsoft.EntityFrameworkCore;
using Northwind.Application.Interfaces;
using Northwind.Core.Models;
using NorthwindApp.Infrastructure.Data;
using System;

namespace Northwind.Infrastructure.Repositories
{
    public class ShipperRepos : IShipperRepository
    {
        private readonly NorthwindContext _context;

        
        public ShipperRepos(NorthwindContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Shipper> GetAllShipper()
        {
            return _context.Shippers.ToList();
        }

        
        public Shipper GetByIdShipper(int id)
        {
            return _context.Shippers.Find(id);
        }

        
        public void AddShipper(Shipper shipper)
        {
            if (shipper == null)
                throw new ArgumentNullException(nameof(shipper));
            _context.Shippers.Add(shipper);
            _context.SaveChanges();
        }

        
        public void UpdateShipper(Shipper shipper)
        {
            if (shipper == null)
                throw new ArgumentNullException(nameof(shipper));
            _context.Entry(shipper).State = EntityState.Modified;
            _context.SaveChanges();
        }

        
        public void DeleteShipper(int id)
        {
            var shipper = _context.Shippers.Find(id);
            if (shipper != null)
            {
                _context.Shippers.Remove(shipper);
                _context.SaveChanges();
            }
        }
    }
}