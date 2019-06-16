using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Services.ServiceModels;
using OnLineVideotech.Web.Models;

namespace OnLineVideotech.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<MovieServiceModel> movies = await this.movieService.GetMovies();

            return View(movies);
        }

        public async Task<IActionResult> MovieDetails(Guid id)
        {
            MovieServiceModel movie = await this.movieService.FindMovie(id);

            return View(movie);
        }        

        [Authorize]
        public IActionResult BuyMovie(Guid id)
        {
            UserBalanceViewModel userBalanceModel = new UserBalanceViewModel();

            return View(userBalanceModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}