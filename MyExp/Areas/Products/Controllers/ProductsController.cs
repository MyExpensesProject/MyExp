using Microsoft.AspNetCore.Mvc;

namespace MyExp.Areas.Products.Controllers;

public class ProductsController : Controller
{
    /// <summary>
    /// Products Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
}