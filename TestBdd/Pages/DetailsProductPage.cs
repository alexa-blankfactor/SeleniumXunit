using System;
using OpenQA.Selenium;
using SeleniumXUnit;
using ProductAPI.Data;

namespace TestBdd.Pages
{
	public class DetailsProductPage:IDetailsProductPage
	{
        private readonly IWebDriver driver;
        public DetailsProductPage(IDriverFixtures driverFixtures)
		{
            this.driver = driverFixtures.Driver;
        }

        IWebElement textname => driver.FindElement(By.Id("Name"));
        IWebElement textDescription => driver.FindElement(By.Id("Description"));
        IWebElement textPrice => driver.FindElement(By.Id("Price"));
        IWebElement ddlProductType => driver.FindElement(By.Id("ProductType"));


        public Product GetProduct() {

            return new Product {
                Name= textname.Text,
                Description= textDescription.Text,
                Price = int.Parse(textPrice.Text),
                ProductType= (ProductType)Enum.Parse<Constans.ProductType>(ddlProductType.Text)
            };

        }
    }
}

