using Microsoft.EntityFrameworkCore;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp_Final.Repository
{
    public class ShipperRepos
    {
        private readonly NorthwindContext _context;

        //CONSTRUCTOR
        public ShipperRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //OBTENER TODOS
        public List<Shipper> GetAllShipper()
        {
            return _context.Shippers.ToList();
        }

        public Shipper? GetShipperById(int id)
        {
            return _context.Shippers.Find(id);
        }

        //AGREGAR
        public void AddShipper(Shipper shipper)
        {
            if (shipper == null)
                throw new ArgumentNullException(nameof(shipper));
            _context.Shippers.Add(shipper);
            _context.SaveChanges();
        }

        //ACTUALIZAR
        public void UpdateShipper(Shipper shipper)
        {
            if (shipper == null)
                throw new ArgumentNullException(nameof(shipper));
            _context.Entry(shipper).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //ELIMINAR
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
