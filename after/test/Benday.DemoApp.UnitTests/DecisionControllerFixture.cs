using Benday.DemoApp.Api;
using Benday.DemoApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Benday.DemoApp.UnitTests;

public class DecisionControllerFixture
{
    private DecisionController? _SystemUnderTest = null;
    public DecisionController SystemUnderTest
    {
        get
        {
            if (_SystemUnderTest == null)
            {
                _SystemUnderTest = new DecisionController(
                    DecisionServiceInstance);
            }

            Assert.NotNull(_SystemUnderTest);

            return _SystemUnderTest;
        }
    }

    private CoolNotCoolDecisionService? _DecisionServiceInstance = null;
    public CoolNotCoolDecisionService DecisionServiceInstance
    {
        get
        {
            if (_DecisionServiceInstance == null)
            {
                _DecisionServiceInstance = new CoolNotCoolDecisionService();
            }

            Assert.NotNull(_DecisionServiceInstance);

            return _DecisionServiceInstance;
        }
    }

    [Fact]
    public void Index_Get()
    {
        // arrange
        
        // act
        var response = SystemUnderTest.Index();

        // assert

        if (response is ViewResult result)
        {
            var actual = result.Model as DecisionResponse;
            Assert.NotNull(actual);
            Assert.False(actual.HasDecision);
        }
        else
        {
            Assert.Fail("Expected ViewResult.");
        }
    }

    [Theory]
    [InlineData("cool", true, "Cool.")]
    [InlineData("rock", false, "Not cool.")]
    [InlineData("thing", false, "Not cool.")]
    public void Index_Post(string item, bool expectedIsCool, string expectedReason)
    {
        // arrange
        
        // act
        var response = SystemUnderTest.Index(item);

        // assert

        if (response is ViewResult result)
        {
            var actual = result.Model as DecisionResponse;
            Assert.NotNull(actual);
            Assert.Equal(expectedIsCool, actual.IsCool);
            Assert.Equal(expectedReason, actual.Reason);
            Assert.True(actual.HasDecision);
            Assert.Equal(item, actual.ItemToCheck);
        }
        else
        {
            Assert.Fail("Expected ViewResult.");
        }
    }
}