using Benday.DemoApp.Api;

namespace Benday.DemoApp.UnitTests;

public class DecisionServiceFixture
{
    private CoolNotCoolDecisionService? _SystemUnderTest = null;
    public CoolNotCoolDecisionService SystemUnderTest
    {
        get
        {
            if (_SystemUnderTest == null)
            {
                _SystemUnderTest = new CoolNotCoolDecisionService();
            }

            Assert.NotNull(_SystemUnderTest);

            return _SystemUnderTest;
        }
    }

    [Fact]
    public void DecisionResponse_HasDecision_FalseWhenConstructed()
    {
        // arrange

        // act
        var actual = new DecisionResponse();

        // assert
        Assert.False(actual.HasDecision);
    }

    [Theory]
    [InlineData("cool", true, "Cool.")]
    [InlineData("rock", false, "Not cool.")]
    [InlineData("thing", false, "Not cool.")]
    public void Decide_EmptyString_NotCool(string item, bool expectedIsCool, string expectedReason)
    {
        // arrange
        var request = new DecisionRequest();
        request.ItemToCheck = item;

        // act
        var actual = SystemUnderTest.Decide(request);

        // assert
        Assert.NotNull(actual);
        Assert.Equal(expectedIsCool, actual.IsCool);
        Assert.Equal(expectedReason, actual.Reason);
        Assert.True(actual.HasDecision);
        Assert.Equal(item, actual.ItemToCheck);
    }
}
