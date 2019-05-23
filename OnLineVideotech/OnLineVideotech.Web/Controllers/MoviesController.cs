using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Services.ServiceModels;
using System;
using System.Collections.Generic;
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
            IEnumerable<MovieServiceModel> movies = await this.movieService.GetMovies();

            return View(movies);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            MovieServiceModel movie = await this.movieService.FindMovie(id);

            return View(movie);
        }
    }
}