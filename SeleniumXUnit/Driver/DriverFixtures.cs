using System;
using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumXUnit.Driver;
using SeleniumXUnit.Setting;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnit
{
    public class DriverFixtures : IDriverFixtures
    {
        IWebDriver driver;
        private readonly IBrowserDriver browserDriver;
        private readonly TestSetting testSetting;

        public DriverFixtures(TestSetting testSetting,IBrowserDriver browserDriver)
        {
            this.testSetting = testSetting;
            this.browserDriver = browserDriver;
            driver = GetWebDriver();
        }

        public IWebDriver Driver => driver;
        private IWebDriver GetWebDriver()
        {


            return testSetting.BrowserType switch
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

