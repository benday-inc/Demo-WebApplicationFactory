namespace Benday.DemoApp.Api;

public class CoolNotCoolDecisionInFrenchService : IDecisionService
{
    public const string ReasonFroid = "Il fait froid!";
    public const string ReasonPasFroid = "Il ne fait pas froid.";

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
                Reason = ReasonFroid,
                ItemToCheck = request.ItemToCheck
            };
        }
        else
        {
            return new DecisionResponse()
            {
                HasDecision = true,
                IsCool = false,
                Reason = ReasonPasFroid,
                ItemToCheck = request.ItemToCheck
            };
        }
    }
}
