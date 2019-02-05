using Microsoft.AspNetCore.Mvc;

namespace OnLineVideotech.Web.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}