using Benday.DemoApp.Api;

namespace Benday.DemoApp.UnitTests;

public class DecisionServiceInFrenchFixture
{
    private CoolNotCoolDecisionInFrenchService? _SystemUnderTest = null;
    public CoolNotCoolDecisionInFrenchService SystemUnderTest
    {
        get
        {
            if (_SystemUnderTest == null)
            {
                _SystemUnderTest = new CoolNotCoolDecisionInFrenchService();
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
    [InlineData("froid", true, "Il fait froid.")]
    [InlineData("chaud", false, "Il ne fait pas froid.")]
    [InlineData("asdfasdf", false, "Il ne fait pas froid.")]
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
