namespace Benday.DemoApp.Api;

public class CoolNotCoolDecisionService : IDecisionService
{
    public DecisionResponse Decide(DecisionRequest request)
    {
        if (string.IsNullOrEmpty(request.ItemToCheck) == true)
        {
            return GetResponse(false, request);
        }
        else if (request.ItemToCheck.ToLowerInvariant() == "cool")
        {
            return GetResponse(true, request);
        }
        else
        {
            return GetResponse(false, request);
        }
    }

    private DecisionResponse GetResponse(bool value, DecisionRequest request)
    {
        if (value == true)
        {
            return new DecisionResponse()
            {
                HasDecision = true,
                IsCool = true,
                Reason = "Cool.",
                ItemToCheck = request.ItemToCheck
            };
        }
        else
        {
            return new DecisionResponse()
            {
                HasDecision = true,
                IsCool = false,
                Reason = "Not cool.",
                ItemToCheck = request.ItemToCheck
            };
        }
    }
}
