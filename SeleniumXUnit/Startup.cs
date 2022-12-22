using System;
using Microsoft.Extensions.DependencyInjection;
using SeleniumXUnit.Driver;

namespace SeleniumXUnit
{
	public class Startup
	{
		public Startup() { }
		
		public void ConfigureServices(IServiceCollection services)
		{
			services.UseWebDriverInitializer(BrowserType.Firefox);
			services.AddScoped<IDriverFixtures, DriverFixtures>();
			services.AddScoped<IBrowserDriver, BrowserDriver>();
		}
		
	}
}

