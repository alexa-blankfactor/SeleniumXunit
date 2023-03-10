using System;
using EATestFramework.Extensions;
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
        IWebElement tbl => driver.FindElement(By.CssSelector(".table"));

        public void CreateProduct()
        {
            lnkProduct.Click();
            lnkCreate.Click();
        }

        public void PerformClickOnSpecialValue(string name, string operation)
        {
 
              tbl.PerformActionOnCell("5","Name",name,operation);
            
        }

    }
}

