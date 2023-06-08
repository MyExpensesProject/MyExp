using Microsoft.AspNetCore.Mvc;

namespace MyExp.Areas.Expenses.Controllers;

public class ExpensesController : Controller
{
    /// <summary>
    /// Expenses Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
}