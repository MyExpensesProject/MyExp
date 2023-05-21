using Microsoft.AspNetCore.Mvc;

namespace MyExp.Areas.Users.Controllers;

public class UsersController : Controller
{
    /// <summary>
    /// Users Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
}