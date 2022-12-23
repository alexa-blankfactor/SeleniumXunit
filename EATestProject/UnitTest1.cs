using EATestProject.Pages;
using OpenQA.Selenium;
using SeleniumXUnit;

namespace EATestProject;

public class UnitTest1 :IDisposable
{

    IWebDriver driver;
    private readonly IHomePage homePage;
    private readonly ICreateProductPage createProductPage;


    public UnitTest1(IDriverFixtures driverFixtures,IHomePage homePage, ICreateProductPage createProductPage)
    { 
        this.homePage = homePage;
        this.createProductPage = createProductPage;
        driver = driverFixtures.Driver;
        driver.Navigate().GoToUrl(new Uri("http://localhost:5002/"));
    }

    [Fact]
    public void Test1()
    {
       
        homePage.CreateProduct();
        createProductPage.EnterProductDetails(new Model.Product{
            Name= "AutoProduct",
            Description="AutoDescription",
            Price=100,
            ProductType=Constans.ProductType.PERIPHARALS

        });

    }

    void IDisposable.Dispose()
    {
        driver.Quit();

    }
}
