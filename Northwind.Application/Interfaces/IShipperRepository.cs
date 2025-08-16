using Northwind.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Application.Interfaces
{
    public interface IShipperRepository
    {
        Task<IEnumerable<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        Task AddAsync(Shipper shipper);
        Task UpdateAsync(Shipper shipper);
        Task DeleteAsync(int id);
    }
}
