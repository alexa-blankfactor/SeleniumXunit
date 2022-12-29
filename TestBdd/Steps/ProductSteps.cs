using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestBdd.Pages;
using FluentAssertions;
using ProductAPI.Repository;
using ProductAPI.Data;

namespace TestBdd.Steps
	{
		[Binding]
		public sealed class ProductSteps
		{
			private readonly IHomePage homePage;
    		private readonly ICreateProductPage createProductPage;
    		private readonly IDetailsProductPage detailsProductPage;
		private readonly IEditProductPage editProductPage;
			private readonly IProductRepository productRepository;
			private  ScenarioContext scenarioContext;

		
			public ProductSteps(ScenarioContext scenarioContext,IHomePage homePage, ICreateProductPage createProductPage,IDetailsProductPage detailsProductPage,IEditProductPage editProductPage ,IProductRepository productRepository)
			{
				this.scenarioContext=scenarioContext;
				this.homePage = homePage;
				this.createProductPage = createProductPage;
				this.detailsProductPage = detailsProductPage;
				this.productRepository = productRepository;
				this.editProductPage = editProductPage;

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
			
			[When(@"I click the (.*) link of the newly created product")]
			public void WhenIclickthedetailslinkofthenewlycreatedproduct(string operation)
			{
				var product =scenarioContext.Get<Product>();
				homePage.PerformClickOnSpecialValue(product.Name, operation);
			}

			[Then(@"I see all the product details are created as expected")]
			public void ThenIseealltheproductdetailsarecreatedasexpected()
			{
				 scenarioContext.Get<Product>().Should().BeEquivalentTo(detailsProductPage.GetProduct(), options => options.Excluding(product=>product.Id));
			}

			
			[When(@"I Edit the product details with following")]
			public void WhenIEdittheproductdetailswithfollowing(Table table)
			{
				var product= table.CreateInstance<Product>();
				editProductPage.EditProduct(product);
				scenarioContext.Set<Product>(product);
				
			}


			
		





            
			
		}
	}