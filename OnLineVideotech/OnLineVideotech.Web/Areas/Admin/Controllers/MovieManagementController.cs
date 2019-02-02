using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Interfaces;
using OnLineVideotech.Web.Areas.Admin.Models;
using OnLineVideotech.Web.Controllers;

namespace OnLineVideotech.Web.Areas.Admin.Controllers
{
    public class MovieManagementController : BaseAdminController
    {
        private readonly IMovieService movies;
        private readonly UserManager<User> userManager;

        public MovieManagementController(
            IMovieService movies,
            UserManager<User> userManager)
        {
            this.movies = movies;
            this.userManager = userManager;
        }

        public IActionResult Add() => this.View();

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