using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumXUnit.Driver;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumXUnit;

public class UnitTest2: IDisposable


{
    IWebDriver driver;


    public UnitTest2(IDriverFixtures driverFixtures)
    {

        driver = driverFixtures.Driver;
        driver.Navigate().GoToUrl(new Uri("http://localhost:5002/"));
    }


    [Fact]
    public void Test2()
    {
        
        driver.FindElement(By.LinkText("Product")).Click();
        driver.FindElement(By.LinkText("Create")).Click();
        driver.FindElement(By.Id("Name")).SendKeys("mouse");
        driver.FindElement(By.Id("Description")).SendKeys("brand: logictech");
        driver.FindElement(By.Id("Price")).SendKeys("100");
        SelectElement select = new SelectElement(driver.FindElement(By.Id("ProductType")));
        select.SelectByValue("3");
        driver.FindElement(By.Id("Create")).Submit();

    }
    public void Dispose()
    {
        driver.Quit();
    }
}
