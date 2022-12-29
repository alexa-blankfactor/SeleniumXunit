using System;
using EATestFramework.Extensions;
using OpenQA.Selenium;
using ProductAPI.Data;
using SeleniumXUnit;
using TestBdd.Drivers;

namespace TestBdd.Pages
{
    public class EditProductPage : IEditProductPage
    {
        private readonly IWebDriver driver;
        public EditProductPage(IDriverFixtures driverFixtures)
        {
            this.driver = driverFixtures.Driver;
        }

        IWebElement textname => driver.FindElement(By.Id("Name"));
        IWebElement textDescription => driver.FindElement(By.Id("Description"));
        IWebElement textPrice => driver.FindElement(By.Id("Price"));
        IWebElement ddlProductType => driver.FindElement(By.Id("ProductType"));
        IWebElement btnSave => driver.FindElement(By.CssSelector(".btn"));

        public void EditProduct(Product product)
        {
            textname.ClearAndEnterText(product.Name);
            textDescription.ClearAndEnterText(product.Description);
            textPrice.ClearAndEnterText(product.Price.ToString());
            ddlProductType.ClearAndEnterText(product.ProductType.ToString());
            btnSave.Click();
        }
    }
}

