using Microsoft.AspNetCore.Mvc;

namespace CarBook.webUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmetler";
            ViewBag.v2 = "Hizmetlerimiz";
           return View();
        }
    }
}
