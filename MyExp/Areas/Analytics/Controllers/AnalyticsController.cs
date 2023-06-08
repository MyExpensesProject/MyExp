using Microsoft.AspNetCore.Mvc;

namespace MyExp.Areas.Analytics.Controllers;

public class AnalyticsController : Controller
{
    /// <summary>
    /// Analytics Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
}