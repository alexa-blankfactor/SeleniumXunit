using System;
using EATestFramework.Extensions;
using EATestProject.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumXUnit;

namespace EATestProject.Pages
{
    public class CreateProductPage : ICreateProductPage
    {
        private readonly IWebDriver driver;
        public CreateProductPage(IDriverFixtures driverFixtures)
        {
            this.driver = driverFixtures.Driver;
        }

        IWebElement textname => driver.FindElement(By.Id("Name"));
        IWebElement textDescription => driver.FindElement(By.Id("Description"));
        IWebElement textPrice => driver.FindElement(By.Id("Price"));
        IWebElement ddlProductType => driver.FindElement(By.Id("ProductType"));
        IWebElement btnCreate => driver.FindElement(By.Id("Create"));


        public void EnterProductDetails(Product product)
        {
            textname.SendKeys(product.Name);
            textDescription.ClearAndEnterText(product.Description);
            textPrice.SendKeys(product.Price.ToString());
            ddlProductType.SelectDropDownByText(product.ProductType.ToString());
            btnCreate.Submit();

        }
    }
}

