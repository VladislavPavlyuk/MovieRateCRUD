using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieRateCRUD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "ASP.NET Core MVC";
            ViewData["Head"] = "ASP.NET Core Razor Pages";
            return View();
        }

        public RedirectResult RedirectMethod()
        {
            return Redirect("/Home/Index");
        }
    }
}

