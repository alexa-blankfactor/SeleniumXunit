using System;
using EATestProject.Pages;
using Microsoft.Extensions.DependencyInjection;
using SeleniumXUnit.Driver;

namespace EATestProject
{
	public class Startup
	{
		public Startup() { }
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.UseWebDriverInitializer(BrowserType.Firefox);
			services.AddScoped<SeleniumXUnit.IDriverFixtures, SeleniumXUnit.DriverFixtures>();
			services.AddScoped<IBrowserDriver, BrowserDriver>();
			services.AddScoped<IHomePage, HomePage>();
            services.AddScoped<ICreateProductPage, CreateProductPage>();
        }
		
	}
}

