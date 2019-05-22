using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Services.Interfaces;
using System.Threading.Tasks;

namespace OnLineVideotech.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Get()
        {
            await this.movieService.GetMovies();

            return View();
        }
    }
}