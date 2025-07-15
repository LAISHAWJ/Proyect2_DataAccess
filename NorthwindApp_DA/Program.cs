using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthwindApp_DA.CrearEditRegisFrm;
using NorthwindApp_DA.Data;
using NorthwindApp_DA.Models;
using NorthwindApp_DA.Repository;
using NorthwindApp_DA.Validators;
using System;
using System.Configuration;

namespace NorthwindApp_DA
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            /*Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("Logs/app.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();*/
                //Log.Information("Iniciando la aplicación Northwind CRUD");

                var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

                var services = new ServiceCollection();
                services.AddSingleton<IConfiguration>(configuration);
                services.AddDbContext<NorthwindContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("NorthwindDb"));
                });

                //services.AddScoped<ILogger>(provider => Log.Logger);
                services.AddTransient<MenuFrm>();
                services.AddTransient<CategoryFrm>();
                services.AddTransient<CategoryCrearFrm>();
                services.AddTransient<CategoryValid>();
                services.AddTransient<CategoryRepos>();

                ServiceProvider = services.BuildServiceProvider();
                var context = ServiceProvider.GetService<NorthwindContext>();

                ApplicationConfiguration.Initialize();

                var menufrm = ServiceProvider.GetService<MenuFrm>();
                Application.Run(menufrm);
            
        }
    }
}