using Microsoft.AspNetCore.Mvc;

namespace EinTech.Test.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => View();
    }
}
