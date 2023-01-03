using System;
using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using SeleniumXUnit.Driver;
using SeleniumXUnit.Setting;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnit
{
    public class DriverFixtures : IDriverFixtures,IDisposable
    {
        
        IWebDriver driver;
        private readonly IBrowserDriver browserDriver;
        private readonly TestSetting testSetting;

        public DriverFixtures(TestSetting testSetting,IBrowserDriver browserDriver)
        {
            this.testSetting = testSetting;
            this.browserDriver = browserDriver;
            if (testSetting.ExecutionType == ExecutionType.Local)
            {
                driver = GetWebDriver();
            }
            else
            {
                driver = new RemoteWebDriver(testSetting.SeleniumGridUrl, GetBrowserOption());
            }
            
            
            driver.Navigate().GoToUrl(testSetting.ApplicationUrl);
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

        private dynamic GetBrowserOption()
        {
            switch (testSetting.BrowserType)
            {
                case BrowserType.Firefox:
                    {
                        var firefoxOption = new FirefoxOptions();

                        firefoxOption.AddAdditionalFirefoxOption("se:recordVideo", true);
                        return firefoxOption;
                    }
                case BrowserType.Edge:
                    return new EdgeOptions();
                case BrowserType.Safari:
                    return new SafariOptions();
                case BrowserType.Chrome:
                    {
                        var chromeOption = new ChromeOptions();
                        chromeOption.AddAdditionalOption("se:recordVideo", true);
                        return chromeOption;
                    }
                default:
                    return new ChromeOptions();

            }
        }



        public void Dispose()
        {
            driver.Quit();
        }
    }
}

