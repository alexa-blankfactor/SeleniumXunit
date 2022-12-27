using System;
using TestBdd.Pages;
using SeleniumXUnit.Driver;
using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace TestBdd
{
	public static class Startup
	{
	
		[ScenarioDependencies]
		public static IServiceCollection CreateServices()
		{
			var services = new ServiceCollection();
			services.UseWebDriverInitializer();
			services.AddScoped<SeleniumXUnit.IDriverFixtures, SeleniumXUnit.DriverFixtures>();
			services.AddScoped<IBrowserDriver, BrowserDriver>();
			services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ICreateProductPage, CreateProductPage>();
            services.AddScoped<IDetailsProductPage, DetailsProductPage>();

			return services;	
		}
		
	}
}

