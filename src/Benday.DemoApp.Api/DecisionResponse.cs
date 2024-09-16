namespace Benday.DemoApp.Api;

public class DecisionResponse
{
    public bool HasDecision { get; set; } = false;
    public string ItemToCheck { get; set; } = string.Empty;
    public bool IsCool { get; set; }
    public string Reason { get; set; } = string.Empty;
}
