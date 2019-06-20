using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Services.ServiceModels;
using OnLineVideotech.Web.Models;

namespace OnLineVideotech.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMovieService movieService;
        private readonly IUserBalanceService userBalanceService;

        public MovieController(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMovieService movieService,
            IUserBalanceService userBalanceService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.movieService = movieService;
            this.userBalanceService = userBalanceService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<MovieServiceModel> movies = await this.movieService.GetMovies();

            if (User.Identity.IsAuthenticated)
            {
                User user = await userManager.GetUserAsync(HttpContext.User);
                IList<string> roles = await userManager.GetRolesAsync(user);
                string role = roles.SingleOrDefault();

                foreach (MovieServiceModel movie in movies)
                {
                    MovieServiceModel movieModel = await this.movieService.FindMovie(movie.Id);

                    movie.Price = movieModel.Prices.SingleOrDefault(x => x.Role.Name == role).MoviePrice;
                }
            }

            return View(movies);
        }

        public async Task<IActionResult> MovieDetails(Guid id)
        {            
            MovieServiceModel movieModel = await this.movieService.FindMovie(id);

            if (User.Identity.IsAuthenticated)
            {
                User user = await userManager.GetUserAsync(HttpContext.User);
                IList<string> roles = await userManager.GetRolesAsync(user);

                foreach (string role in roles)
                {
                    movieModel.Price = movieModel.Prices.SingleOrDefault(x => x.Role.Name == role).MoviePrice;
                }
            }          

            return View(movieModel);
        }

        [Authorize]
        public async Task<IActionResult> BuyMovie(Guid id)
        {
            MovieServiceModel movieModel = await this.movieService.FindMovie(id);

            User user = await userManager.GetUserAsync(HttpContext.User);
            IList<string> roles = await userManager.GetRolesAsync(user);
            string role = roles.SingleOrDefault();

            movieModel.Price = movieModel.Prices.SingleOrDefault(x => x.Role.Name == role).MoviePrice;

            UserBalanceServiceModel userBalanceModel = new UserBalanceServiceModel();
            userBalanceModel = this.userBalanceService.GetUserBalance(user.Id);

            BuyMovieViewModel buyMovieViewModel = new BuyMovieViewModel();
            buyMovieViewModel.Balance = userBalanceModel.Balance;
            buyMovieViewModel.MovieId = id;
            buyMovieViewModel.Price = movieModel.Price;
            buyMovieViewModel.MovieName = movieModel.Name;

            return View(buyMovieViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult BuyMovie(BuyMovieViewModel buyMovieViewModel)
        {

            return View(buyMovieViewModel);
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