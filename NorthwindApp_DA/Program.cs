using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Interfaces;
using Northwind.Application.Services;
using Northwind.Application.Servicios;
using Northwind.Application.Validators;
using Northwind.Infrastructure.Repositories;
using NorthwindApp.Infrastructure.Data;
using NorthwindApp_Final;
using NorthwindApp_Final.CrearEditRegisFrm;
using NorthwindApp_Final.PrincipalForms;


namespace NorthwindApp_Final
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
           
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var menuform = serviceProvider.GetRequiredService<MenuFrm>();
                Application.Run(menuform);
            }

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NorthwindDb")));

            // Repositories
            services.AddTransient<ICategoryRepository, CategoryRepos>();
            services.AddTransient<ICustomerRepository, CustomerRepos>();
            services.AddTransient<IEmployeeRepository, EmployeeRepos>();
            services.AddTransient<ISupplierRepository, SupplierRepos>();
            services.AddTransient<IShipperRepository, ShipperRepos>();
            services.AddTransient<IProductRepository, ProductRepos>();
            services.AddTransient<IOrderRepository, OrderRepos>();
            services.AddTransient<IOrderDetailsRepository, OrderDetailsRepos>();

            // Services
            services.AddTransient<CategoryService>();
            services.AddTransient<CustomerService>();
            services.AddTransient<EmployeeService>();
            services.AddTransient<SupplierService>();
            services.AddTransient<ShipperService>();
            services.AddTransient<ProductService>();
            services.AddTransient<OrderService>();
            services.AddTransient<OrderDetailsService>();

            // Validators
            services.AddValidatorsFromAssemblyContaining<CategoryValid>();
            services.AddValidatorsFromAssemblyContaining<CustomerValid>();
            services.AddValidatorsFromAssemblyContaining<EmployeeValid>();
            services.AddValidatorsFromAssemblyContaining<SupplierValid>();
            services.AddValidatorsFromAssemblyContaining<ShipperValid>();
            services.AddValidatorsFromAssemblyContaining<ProductValid>();
            services.AddValidatorsFromAssemblyContaining<OrderValid>();

            // Forms
            services.AddTransient<CategoryFrm>();
            services.AddTransient<CategoryCrearFrm>();
            services.AddTransient<CustomerFrm>();
            services.AddTransient<CustomerCrearFrm>();
            services.AddTransient<EmployeeFrm>();
            services.AddTransient<EmployeeCrearFrm>();
            services.AddTransient<SupplierFrm>();
            services.AddTransient<SuppliercrearFrm>();
            services.AddTransient<ShipperFrm>();
            services.AddTransient<ShipperCrearFrm>();
            services.AddTransient<ProductsFrm>();
            services.AddTransient<ProductcrearFrm>();
            services.AddTransient<OrderFrm>();
            services.AddTransient<OrderCrearFrm>();
            services.AddTransient<OrderDetailsFrm>();
        }
}   }