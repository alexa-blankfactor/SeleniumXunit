using System;
using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumXUnit.Driver;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnit
{
	public class DriverFixtures:IDisposable
	{
        IWebDriver driver;
        private readonly IContainer container;

        public DriverFixtures(IContainer container,BrowserType browserType )
		{
            this.container = container;
            driver = GetWebDriver(browserType);
        }

        public IWebDriver Driver => driver;
        private IWebDriver GetWebDriver(BrowserType browserType) {
            var driver = container.Resolve<IBrowserDriver>();

            return browserType switch
            {
                BrowserType.Chrome => driver.GetChromeDriver(),
                BrowserType.Firefox => driver.GetFirefoxDriver(),
                _ => driver.GetChromeDriver()
            };

        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

