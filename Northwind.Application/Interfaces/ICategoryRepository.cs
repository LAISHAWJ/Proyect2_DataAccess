using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Core.Models;
using System.Threading.Tasks;

namespace Northwind.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
