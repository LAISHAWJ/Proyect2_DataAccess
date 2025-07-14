using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace NorthwindApp_DA
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }
        [STAThread]
        static void Main()
        {
            

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

           




            try
            {
                Log.Information("Iniciando la aplicación Northwind CRUD");

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(configuration);
                services.AddDbContext<NorthwindContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("NorthwindDb")));

                using (var serviceProvider = services.BuildServiceProvider())
                {
                    var context = serviceProvider.GetService<NorthwindContext>();
                    context.Database.Migrate();
                }

                Application.Run(new MenuFrm(serviceProvider));
            }

            catch (Exception ex)
            {
                Log.Error(ex, "La aplicación falló al iniciarse");
                MessageBox.Show("Error al iniciar la aplicación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Log.CloseAndFlush();
            }
                
        }
    }
}