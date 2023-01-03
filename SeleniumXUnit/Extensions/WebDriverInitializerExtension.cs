using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using SeleniumXUnit.Setting;

namespace SeleniumXUnit.Driver
{
	public static class WebDriverInitializerExtension
	{
		public static IServiceCollection UseWebDriverInitializer(this IServiceCollection services)
		{
			services.AddSingleton(ReadConfig());
			return services;
		}

		private static TestSetting ReadConfig()
		{
			var enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			var configFile = File.ReadAllText(Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().Location) + $"/appsettings.{enviromentName}.json");
			var jsonSerializeOption = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true
			};
			jsonSerializeOption.Converters.Add(new JsonStringEnumConverter());
			var testSettings=JsonSerializer.Deserialize<TestSetting>(configFile,jsonSerializeOption);
			return testSettings;
		}
	}
}

