using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductAPI;

namespace EATestIntegration;

public class UnitTest1 : IClassFixture<WebApplicationFactory<ProductAPI.Startup>>
{

    private readonly WebApplicationFactory<Startup> webApplicationFactory;

    public UnitTest1(WebApplicationFactory<Startup> webApplicationFactory)
    {
        this.webApplicationFactory = webApplicationFactory;
    }



    [Fact]
    public void Test1()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5001/");
        var response = client.Send(new HttpRequestMessage(HttpMethod.Get, "Product/GetProducts"));
        //response.Content.ReadAsStringAsync().Result;

        response.EnsureSuccessStatusCode();

    }

    [Fact]
    public async Task TestWithWebAppFactory()
    {
        var webClient = webApplicationFactory.CreateClient();
        var product = await webClient.GetAsync("/Product/GetProducts");
        var result = product.Content.ReadAsStringAsync().Result;
        result.Should().Contain("Keyboard");
    }
}

