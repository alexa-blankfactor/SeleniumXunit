using System;
using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumXUnit.Driver;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnit
{
    public class DriverFixtures : IDriverFixtures
    {
        IWebDriver driver;
        private readonly IBrowserDriver browserDriver;

        public DriverFixtures(IBrowserDriver browserDriver)
        {
            this.browserDriver = browserDriver;
            driver = GetWebDriver();
        }

        public IWebDriver Driver => driver;
        private IWebDriver GetWebDriver(BrowserType browserType = BrowserType.Chrome)
        {


            return browserType switch
            {
                BrowserType.Chrome => browserDriver.GetChromeDriver(),
                BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
                _ => browserDriver.GetChromeDriver()
            };

        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

