using Benday.DemoApp.Api;
using Microsoft.AspNetCore.Mvc;

namespace Benday.DemoApp.Web.Controllers;
public class DecisionController : Controller
{
    private readonly IDecisionService _DecisionService;

    public DecisionController(IDecisionService decisionService)
    {
        _DecisionService = decisionService;
    }

    public IActionResult Index()
    {
        var model = new DecisionResponse();

        return View(model);
    }

    [HttpPost]
    public IActionResult Index([FromForm] string itemToCheck)
    {
        var request = new DecisionRequest();

        request.ItemToCheck = itemToCheck;

        var model = _DecisionService.Decide(request);

        return View(model);
    }
}
