namespace Benday.DemoApp.Api;

public interface IDecisionService
{
    DecisionResponse Decide(DecisionRequest request);
}
