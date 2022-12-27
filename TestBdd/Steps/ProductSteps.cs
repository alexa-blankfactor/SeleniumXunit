using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestBdd.Pages;
using TestBdd.Model;
using FluentAssertions;

namespace TestBdd.Steps
	{
		[Binding]
		public sealed class ProductSteps
		{
			private readonly IHomePage homePage;
    		private readonly ICreateProductPage createProductPage;
    		private readonly IDetailsProductPage detailsProductPage;
			private  ScenarioContext scenarioContext;

		
			public ProductSteps(ScenarioContext scenarioContext,IHomePage homePage, ICreateProductPage createProductPage,IDetailsProductPage detailsProductPage)
			{
				this.scenarioContext=scenarioContext;
				this.homePage = homePage;
				this.createProductPage = createProductPage;
				this.detailsProductPage = detailsProductPage;

			}
			
			[Given(@"I click thew product menu")]
			public void GivenIclickthewproductmenu()
			{
				homePage.ClickProduct();
			}
			
			[Given(@"I click the ""(.*)"" link")]
			public void GivenIclickthelink(string args1)
			{
				homePage.ClickCreate();
			}
			
			[Given(@"I create product with following details")]
			public void GivenIcreateproductwithfollowingdetails(Table table)
			{
				var product= table.CreateInstance<Product>();
				createProductPage.EnterProductDetails(product);
				scenarioContext.Set<Product>(product);
			}
			
			[When(@"I click the details link of the newly created product")]
			public void WhenIclickthedetailslinkofthenewlycreatedproduct()
			{
				var product =scenarioContext.Get<Product>();
				homePage.PerformClickOnSpecialValue(product.Name, "Details");
			}

			[Then(@"I see all the product details are created as expected")]
			public void ThenIseealltheproductdetailsarecreatedasexpected()
			{
				 scenarioContext.Get<Product>().Should().BeEquivalentTo(detailsProductPage.GetProduct(), options => options.Excluding(product=>product.Id));
			}




            
			
		}
	}