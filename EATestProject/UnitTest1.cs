using AutoFixture.Xunit2;
using EATestProject.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using SeleniumXUnit;

namespace EATestProject;

public class UnitTest1 
{

    IWebDriver driver;
    private readonly IHomePage homePage;
    private readonly ICreateProductPage createProductPage;
    private readonly IDetailsProductPage detailsProductPage;


    public UnitTest1(IHomePage homePage, ICreateProductPage createProductPage,IDetailsProductPage detailsProductPage)
    { 
        this.homePage = homePage;
        this.createProductPage = createProductPage;
        this.detailsProductPage = detailsProductPage;
    }

    [Theory,AutoData]
    public void Test1(Model.Product product)
    {
        homePage.CreateProduct();
        createProductPage.EnterProductDetails(product);
        homePage.PerformClickOnSpecialValue(product.Name, "Details");
        product.Should().BeEquivalentTo(detailsProductPage.GetProduct(), options => options.Excluding(product=>product.Id));

    }

    
}
