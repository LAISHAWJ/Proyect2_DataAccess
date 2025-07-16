using Microsoft.EntityFrameworkCore;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;

namespace NorthwindApp_DA.Repository
{
    public class ProductRepos
    {
        private readonly NorthwindContext _context;

        //CONSTRUCTOR
        public ProductRepos(NorthwindContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //OBTENER TODOS
        public List<Product> GetAllProducts()
        {
            return _context.Products
           .Include(p => p.Category)
           .Include(p => p.Supplier)
           .ToList();
        }
        public Product? GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        //AGREGAR
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        //ACTUALIZAR
        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //ELIMINAR
        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.OrderBy(c => c.CategoryName).ToList();
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.OrderBy(s => s.CompanyName).ToList();
        }


    }
}
