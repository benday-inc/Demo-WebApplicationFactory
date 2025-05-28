namespace Benday.DemoApp.Api;

public class CoolNotCoolDecisionInFrenchService : IDecisionService
{
    public DecisionResponse Decide(DecisionRequest request)
    {
        if (string.IsNullOrEmpty(request.ItemToCheck) == true)
        {
            return GetResponse(false, request);
        }
        else if (request.ItemToCheck.ToLowerInvariant() == "froid")
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
                Reason = "Il fait froid.",
                ItemToCheck = request.ItemToCheck
            };
        }
        else
        {
            return new DecisionResponse()
            {
                HasDecision = true,
                IsCool = false,
                Reason = "Il ne fait pas froid.",
                ItemToCheck = request.ItemToCheck
            };
        }
    }
}
