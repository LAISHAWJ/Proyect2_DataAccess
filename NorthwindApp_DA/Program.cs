using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA.CrearEditRegisFrm;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.PrincipalForms;
using NorthwindApp_DA.Repository;
using NorthwindApp_DA.Validators;
using NorthwindApp_Final.PrincipalForms;
using NorthwindApp_Final.Repository;

namespace NorthwindApp_DA
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("NorthwindDb"));
            });

            services.AddTransient<MenuFrm>();

            //ENTIDAD CATEGORIA.
            services.AddTransient<CategoryFrm>();
            services.AddTransient<CategoryCrearFrm>();
            services.AddTransient<CategoryValid>();
            services.AddTransient<CategoryRepos>();

            //ENTIDAD SUPLIDOR.
            services.AddTransient<SupplierFrm>();
            services.AddTransient<SuppliercrearFrm>();
            services.AddTransient<SupplierValid>();
            services.AddTransient<SupplierRepos>();

            //ENTIDAD PRODUCTO.
            services.AddTransient<ProductsFrm>();
            services.AddTransient<ProductcrearFrm>();
            services.AddTransient<ProductValid>();
            services.AddTransient<ProductRepos>();


            //ENTIDAD ORDER & ORDERDETAIL.
            services.AddTransient<OrderFrm>();
            services.AddTransient<OrderDetailsFrm>();
            services.AddTransient<OrderValid>();
            services.AddTransient<OrderRepos>();
            services.AddTransient<OrderCrearFrm>();
            services.AddTransient<OrderDetailsRepos>();


            //ENTIDAD EMPLEADO.
            services.AddTransient<EmployeeFrm>();
            services.AddTransient<EmployeeRepos>();



            //ENTIDAD CLIENTES.
            services.AddTransient<CustomerFrm>();
            services.AddTransient<CustomerRepos>();


            //ENTIDAD TRANSPORTISTAS.
            services.AddTransient<ShipperFrm>();
            services.AddTransient<ShipperRepos>();





            ServiceProvider = services.BuildServiceProvider();
            var context = ServiceProvider.GetService<NorthwindContext>();

            ApplicationConfiguration.Initialize();

            var menufrm = ServiceProvider.GetService<MenuFrm>();
            Application.Run(menufrm);

        }
    }
}