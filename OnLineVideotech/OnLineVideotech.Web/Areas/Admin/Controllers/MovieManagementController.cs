using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Models;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Web.Areas.Admin.Models;
using OnLineVideotech.Web.Controllers;
using OnLineVideotech.Web.Infrastructure.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Web.Areas.Admin.Controllers
{
    public class MovieManagementController : BaseAdminController
    {
        private readonly IMovieService movies;
        private readonly UserManager<User> userManager;
        private readonly IRoleService roleService;

        public MovieManagementController(
            IMovieService movies,
            UserManager<User> userManager,
            IRoleService roleService)
        {
            this.movies = movies;
            this.userManager = userManager;
            this.roleService = roleService;
        }

        public async Task<IActionResult> AddMovie()
        {
            IEnumerable<Role> roles = await roleService.GetAllRoles();

            AddMovieViewModel model = new AddMovieViewModel();
            model.Prices = new List<PriceServiceModel>();

            foreach (Role role in roles)
            {
                PriceServiceModel price = new PriceServiceModel();
                price.Role = role;
                price.Price = 0;
                model.Prices.Add(price);
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
             
           await this.movies.Create(
               model.Name,
               model.Year,
               model.Rating,
               model.VideoPath,
               model.PosterPath,
               model.TrailerPath,
               model.Summary,
               model.Prices);

            TempData.AddSuccessMessage($"Movie '{model.Name}' successfully created");

            return RedirectToAction(nameof(AddMovie));
        }
    }
}