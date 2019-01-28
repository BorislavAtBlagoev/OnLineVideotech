using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Web.Infrastructure;

namespace OnLineVideotech.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class UsersContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}