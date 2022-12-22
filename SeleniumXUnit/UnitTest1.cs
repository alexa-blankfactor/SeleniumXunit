using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumXUnit.Driver;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumXUnit;

public class UnitTest1: IDisposable


{
    IWebDriver driver;
   

    public UnitTest1(IDriverFixtures driverFixtures)
    {

        driver = driverFixtures.Driver;
        driver.Navigate().GoToUrl(new Uri("http://localhost:5002/"));
    }


    [Fact]
    public void Test1()
    {
        
        driver.FindElement(By.LinkText("Product")).Click();
        driver.FindElement(By.LinkText("Create")).Click();
        driver.FindElement(By.Id("Name")).SendKeys("Desktop");
        driver.FindElement(By.Id("Description")).SendKeys("Standing desktop");
        driver.FindElement(By.Id("Price")).SendKeys("200");
        SelectElement select = new SelectElement(driver.FindElement(By.Id("ProductType")));
        select.SelectByValue("1");
        driver.FindElement(By.Id("Create")).Submit();

    }

    void IDisposable.Dispose()
    {
        driver.Quit();
    }
}
