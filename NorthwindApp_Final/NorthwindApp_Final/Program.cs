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
using NorthwindApp_Final.CrearEditRegisFrm;
using NorthwindApp_Final.PrincipalForms;

namespace NorthwindApp_Final
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    try
                    {
                        var menuFrm = scope.ServiceProvider.GetRequiredService<MenuFrm>();
                        Application.Run(menuFrm);
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show($"Error al resolver el formulario principal: {ex.Message}", "Error Fatal",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado al iniciar la aplicación: {ex.Message}", "Error Fatal",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NorthwindDb") ?? throw new InvalidOperationException("La cadena de conexión 'NorthwindDb' no está configurada en appsettings.json")),
                ServiceLifetime.Scoped);

            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepos>();
            services.AddScoped<ICustomerRepository, CustomerRepos>();
            services.AddScoped<IEmployeeRepository, EmployeeRepos>();
            services.AddScoped<ISupplierRepository, SupplierRepos>();
            services.AddScoped<IShipperRepository, ShipperRepos>();
            services.AddScoped<IProductRepository, ProductRepos>();
            services.AddScoped<IOrderRepository, OrderRepos>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepos>();

            // Services
            services.AddScoped<CategoryService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<SupplierService>();
            services.AddScoped<ShipperService>();
            services.AddScoped<ProductService>();
            services.AddScoped<OrderService>();
            services.AddScoped<OrderDetailsService>();

            // Validators
            services.AddValidatorsFromAssemblyContaining<CategoryValid>();
            services.AddValidatorsFromAssemblyContaining<CustomerValid>();
            services.AddValidatorsFromAssemblyContaining<EmployeeValid>();
            services.AddValidatorsFromAssemblyContaining<SupplierValid>();
            services.AddValidatorsFromAssemblyContaining<ShipperValid>();
            services.AddValidatorsFromAssemblyContaining<ProductValid>();
            services.AddValidatorsFromAssemblyContaining<OrderValid>();

            // Forms
            services.AddScoped<MenuFrm>();
            services.AddScoped<CategoryFrm>();
            services.AddScoped<CategoryCrearFrm>();
            services.AddScoped<CustomerFrm>();
            services.AddScoped<CustomerCrearFrm>();
            services.AddScoped<EmployeeFrm>();
            services.AddScoped<EmployeeCrearFrm>();
            services.AddScoped<SupplierFrm>();
            services.AddScoped<SuppliercrearFrm>();
            services.AddScoped<ShipperFrm>();
            services.AddScoped<ShipperCrearFrm>();
            services.AddScoped<ProductsFrm>();
            services.AddScoped<ProductcrearFrm>();
            services.AddScoped<OrderFrm>();
            services.AddScoped<OrderCrearFrm>();
            services.AddScoped<OrderDetailsFrm>();
        }
    }
}