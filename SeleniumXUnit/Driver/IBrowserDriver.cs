using OpenQA.Selenium;

namespace SeleniumXUnit.Driver
{
    public interface IBrowserDriver
    {
        IWebDriver GetChromeDriver();
        IWebDriver GetFirefoxDriver();
    }
}