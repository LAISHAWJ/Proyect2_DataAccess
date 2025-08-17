using Northwind.Core.Models;
using System.Collections.Generic;

namespace Northwind.Application.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategory();
        Category GetByIdCategory(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}