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

    [Fact]
    public async Task Index_Post_Cool_IsCool()
    {
        // arrange
        var factory = new WebApplicationFactory<JustAnEmptyClass>();

        var client = factory.CreateClient();

        var formValueName = "itemToCheck";
        var formValue = "cool";

        var contentToPost = new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
                { formValueName, formValue }
            });

        var expected = "It's cool!";

        // act
        var response = await client.PostAsync("decision/", contentToPost);

        // assert
        Assert.NotNull(response);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        Assert.Contains(expected, content);
    }

    [Fact]
    public async Task Index_Post_Blah_IsNotCool()
    {
        // arrange
        var factory = new WebApplicationFactory<JustAnEmptyClass>();

        var client = factory.CreateClient();

        var formValueName = "itemToCheck";
        var formValue = "blah";

        var contentToPost = new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
                { formValueName, formValue }
            });

        var expected = "It's NOT cool.";

        // act
        var response = await client.PostAsync("decision/", contentToPost);

        // assert
        Assert.NotNull(response);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        Assert.Contains(expected, content);
    }
}
