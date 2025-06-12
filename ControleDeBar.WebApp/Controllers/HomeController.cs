using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}