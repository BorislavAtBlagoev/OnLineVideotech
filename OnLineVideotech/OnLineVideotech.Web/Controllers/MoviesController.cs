using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnLineVideotech.Web.Controllers
{
    public class MoviesController : Controller
    {
        [Authorize]
        public IActionResult Add() => this.View();
    }
}