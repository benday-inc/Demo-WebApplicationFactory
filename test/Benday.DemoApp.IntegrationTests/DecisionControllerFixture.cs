using Benday.DemoApp.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benday.DemoApp.IntegrationTests;
public class DecisionControllerFixture
{
    [Fact]
    public async Task Index_Get_ReturnsSuccess()
    {
        // arrange
        var factory = new WebApplicationFactory<JustAnEmptyClass>();

        var client = factory.CreateClient();

        // act
        var response = await client.GetAsync("decision/");

        // assert
        Assert.NotNull(response);

        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode == false)
        {
            TestUtilities.CheckForDependencyError(content);
        }

        Assert.True(response.IsSuccessStatusCode);
    }
}
