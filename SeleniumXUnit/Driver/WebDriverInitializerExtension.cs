using System;
using Microsoft.Extensions.DependencyInjection;
using SeleniumXUnit.Setting;

namespace SeleniumXUnit.Driver
{
	public static class WebDriverInitializerExtension
	{
		public static IServiceCollection UseWebDriverInitializer(this IServiceCollection services,BrowserType browserType)
		{
			services.AddSingleton(new TestSetting { BrowserType = browserType });
			return services;
		}
	}
}

