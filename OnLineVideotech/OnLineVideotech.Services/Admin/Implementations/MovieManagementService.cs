using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Interfaces;
using OnLineVideotech.Services.Admin.ServiceModels;

namespace OnLineVideotech.Services.Admin.Implementations
{
    public class MovieManagementService : BaseService, IBaseService, IMovieManagementService
    {
        private readonly IGenreService genreService;
        private readonly IPriceService priceService;
        private readonly IRoleService roleService;

        public MovieManagementService(
            OnLineVideotechDbContext db,
            IGenreService genreService,
            IPriceService priceService,
            IRoleService roleService) : base(db)
        {
            this.genreService = genreService;
            this.priceService = priceService;
            this.roleService = roleService;
        }

        public async Task Create(
            string name,
            DateTime year,
            double rating,
            string videoPath,
            string posterPath,
            string trailerPath,
            string summary,
            List<PriceServiceModel> prices,
            List<GenreServiceModel> genres)
        {
            Movie movie = new Movie
            {
                Name = name,
                Year = year,
                Rating = rating,
                VideoPath = videoPath,
                PosterPath = posterPath,
                TrailerPath = trailerPath,
                Summary = summary,
            };

            movie.Genres = genres
                .Where(g => g.IsSelected)
                .Select(g => new GenreMovie
                {
                    GenreId = g.Id,
                    MovieId = movie.Id
                })
                .ToList();

            movie.Prices = prices
                .Select(p => new Price
                {
                    MovieId = movie.Id,
                    RoleId = p.RoleId,
                    MoviePrice = p.Price
                })
                .ToList();

            this.Db.Add(movie);
            await base.SaveChanges();
        }

        public async Task<MovieAdminServiceModel> FindMovie(Guid id)
        {
            Movie movie = await this.Db.Movies.FindAsync(id);           
            List<Genre> genresMovie = await this.genreService.GetAllGenreForMovie(movie.Id);
            List<GenreServiceModel> allGenres = await this.genreService.GetAllGenres();

            List<GenreServiceModel> genresMovieModel = new List<GenreServiceModel>();

            foreach (var genre in allGenres)
            {
                GenreServiceModel genreServiceModel = new GenreServiceModel();
                genreServiceModel.Id = genre.Id;
                genreServiceModel.Name = genre.Name;

                if (genresMovie.Any(x => x.Id == genre.Id))
                {
                    genreServiceModel.IsSelected = true;
                }
                else
                {
                    genreServiceModel.IsSelected = false;
                }

                genresMovieModel.Add(genreServiceModel);
            }

            List<Price> prices = await this.priceService.GetAllPricesForMovie(movie.Id);
            List<PriceServiceModel> pricesServiceMovel = prices.Select(p => new PriceServiceModel
            {
                RoleId = p.RoleId,
                Price = p.MoviePrice,
                Role = p.Role
            })
            .ToList();

            foreach (var price in pricesServiceMovel)
            {
                Role role = await this.roleService.FindRole(price.RoleId);

                price.Role = role;
            }

            return new MovieAdminServiceModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Year = movie.Year,
                Rating = movie.Rating,
                VideoPath = movie.VideoPath,
                PosterPath = movie.PosterPath,
                TrailerPath = movie.TrailerPath,
                Summary = movie.Summary,
                Genres = genresMovieModel,
                Prices = pricesServiceMovel
            };
        }
    }
}