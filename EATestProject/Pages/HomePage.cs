using System;
using OpenQA.Selenium;
using SeleniumXUnit;

namespace EATestProject.Pages
{
    public class HomePage : IHomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IDriverFixtures driverFixutes)
        {
            this.driver = driverFixutes.Driver;
        }

        IWebElement lnkProduct => driver.FindElement(By.LinkText("Product"));
        IWebElement lnkCreate => driver.FindElement(By.LinkText("Create"));

        public void CreateProduct()
        {
            lnkProduct.Click();
            lnkCreate.Click();
        }

    }
}

