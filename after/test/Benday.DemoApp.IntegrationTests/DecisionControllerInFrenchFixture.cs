using Benday.DemoApp.Api;
using Benday.DemoApp.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benday.DemoApp.IntegrationTests;
public class DecisionControllerInFrenchFixture
{
    [Fact]
    public async Task Index_Get_ReturnsSuccess()
    {
        // arrange
        var factory = GetFactoryInstance();

        // ChangeServiceToFrench(factory);

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
    public async Task Index_Post_Froid_IsFroid()
    {
        // arrange
        var factory = GetFactoryInstance();

        var client = factory.CreateClient();

        var formValueName = "itemToCheck";
        var formValue = "Froid";

        var contentToPost = new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
                { formValueName, formValue }
            });

        var expected = CoolNotCoolDecisionInFrenchService.ReasonFroid;

        // act
        var response = await client.PostAsync("decision/", contentToPost);

        // assert
        Assert.NotNull(response);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        Assert.Contains(expected, content);
    }

    [Fact]
    public async Task Index_Post_Blah_IsNotFroid()
    {
        // arrange
        var factory = GetFactoryInstance();

        var client = factory.CreateClient();

        var formValueName = "itemToCheck";
        var formValue = "blah";

        var contentToPost = new FormUrlEncodedContent(
            new Dictionary<string, string>
            {
                { formValueName, formValue }
            });

        var expected = CoolNotCoolDecisionInFrenchService.ReasonPasFroid;

        // act
        var response = await client.PostAsync("decision/", contentToPost);

        // assert
        Assert.NotNull(response);

        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();

        Assert.Contains(expected, content);
    }

    private static WebApplicationFactory<JustAnEmptyClass> GetFactoryInstance()
    {
        var factory = new WebApplicationFactory<JustAnEmptyClass>().WithWebHostBuilder(config =>
        {
            config.ConfigureServices(services =>
            {
                // replace the default decision service with the French version
                services.RemoveAll(typeof(Benday.DemoApp.Api.IDecisionService));
                services.AddScoped<Benday.DemoApp.Api.IDecisionService, Benday.DemoApp.Api.CoolNotCoolDecisionInFrenchService>();
            });
        });
        return factory;
    }
}
