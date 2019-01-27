using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Interfaces;
using OnLineVideotech.Web.Models.Movies;

namespace OnLineVideotech.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movies;
        private readonly UserManager<User> userManager;

        public MoviesController(
            IMovieService movies,
            UserManager<User> userManager)
        {
            this.movies = movies;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Add() => this.View();

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddMovieViewModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return View(movieModel);
            }
             
           this.movies.Create(
               movieModel.Name,
               movieModel.Year,
               movieModel.Rating,
               movieModel.VideoPath,
               movieModel.PosterPath,
               movieModel.TrailerPath,
               movieModel.Summary,
               5);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}