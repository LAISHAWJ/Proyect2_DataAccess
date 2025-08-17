using Northwind.Core.Models;
using System.Collections.Generic;

namespace Northwind.Application.Interfaces
{
    public interface IShipperRepository
    {
        IEnumerable<Shipper> GetAllShipper();
        Shipper GetByIdShipper(int id);
        void AddShipper(Shipper shipper);
        void UpdateShipper(Shipper shipper);
        void DeleteShipper(int id);
    }
}