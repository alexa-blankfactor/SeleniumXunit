using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Data;
using ProductAPI.Repository;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TestBdd.Steps
{
    [Binding]
    public sealed class ReusableSteps
    {
        private  ScenarioContext scenarioContext;
        private IProductRepository productRepository;
        public ReusableSteps(ScenarioContext scenarioContext,IProductRepository productRepository)
        {
            this.scenarioContext= scenarioContext;
            this.productRepository=productRepository;
        }
        
        [Then(@"I delete the product ""(.*)"" for cleanup")]
        public void ThenIdeletetheproductforcleanup(string productName)
        {
            productRepository.DeleteProduct(productName);
        }

        
        [Given(@"I ensure the following product is created")]
        public void GivenIensurethefollowingprojectiscreated(Table table)
        {
            var product= table.CreateInstance<Product>();
            productRepository.AddProduct(product);
            scenarioContext.Set<Product>(product);
        }



        
    }
}