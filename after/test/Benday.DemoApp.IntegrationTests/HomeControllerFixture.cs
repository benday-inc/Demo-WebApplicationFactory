using Benday.DemoApp.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benday.DemoApp.IntegrationTests;
public class HomeControllerFixture
{
    [Fact]
    public async void IndexContainsHelloWorld()
    {
        // arrange

        var factory = new WebApplicationFactory<JustAnEmptyClass>();

        var client = factory.CreateClient();

        // act
        var response = await client.GetAsync("/");

        // assert

        Assert.NotNull(response);

        var content = await response.Content.ReadAsStringAsync();

        Assert.Contains("Hello, world!", content);

        Assert.True(response.IsSuccessStatusCode);
    }
}
