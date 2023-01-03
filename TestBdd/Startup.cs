using System;
using TestBdd.Pages;
using SeleniumXUnit.Driver;
using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProductAPI.Data;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Repository;

namespace TestBdd
{
	public static class Startup
	{
	
		[ScenarioDependencies]
		public static IServiceCollection CreateServices()
		{
			var services = new ServiceCollection();

            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(projectPath)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<ProductDbContext>(option => option.UseSqlServer(connectionString));
			services.AddTransient<IProductRepository, ProductRepository>();


			services.UseWebDriverInitializer();
			services.AddScoped<SeleniumXUnit.IDriverFixtures, SeleniumXUnit.DriverFixtures>();
			services.AddScoped<IBrowserDriver, BrowserDriver>();
			services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ICreateProductPage, CreateProductPage>();
            services.AddScoped<IDetailsProductPage, DetailsProductPage>();
            services.AddScoped<IEditProductPage, EditProductPage>();

            return services;	
		}
		
	}
}

