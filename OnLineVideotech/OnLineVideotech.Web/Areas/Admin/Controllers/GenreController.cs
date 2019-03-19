using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Services.Admin.Models;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Web.Areas.Admin.Models.Genres;
using OnLineVideotech.Web.Infrastructure.Extensions;
using System;
using System.Threading.Tasks;

namespace OnLineVideotech.Web.Areas.Admin.Controllers
{
    public class GenreController : BaseAdminController
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }  

        public async Task<IActionResult> AddGenre()
        {
            AddGenreViewModel model = new AddGenreViewModel();
            model.Genres = await this.genreService.GetAllGenres();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGenre(AddGenreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.genreService.Create(model.Name);

            TempData.AddSuccessMessage($"Genre '{model.Name}' successfully created");

            return RedirectToAction(nameof(AddGenre));
        }

        public async Task<IActionResult> EditGenre(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GenreServiceModel genre = await this.genreService.FindGenre(id);

            return View(id);
        }
    }
}