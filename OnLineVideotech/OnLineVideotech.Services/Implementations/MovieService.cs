using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Interfaces;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Services.ServiceModels;

namespace OnLineVideotech.Services.Implementations
{
    public class MovieService : BaseService, IBaseService, IMovieService
    {
        private IPriceService priceService;

        public MovieService(OnLineVideotechDbContext db, IPriceService priceService) : base(db)
        {
            this.priceService = priceService;
        }

        public async Task<IEnumerable<MovieServiceModel>> GetMovies()
        {
            IEnumerable<MovieServiceModel> movieModel = await this.Db.Movies
                .Select(m => new MovieServiceModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Genres = m.Genres,
                    Rating = m.Rating,
                    PosterPath = m.PosterPath,
                    VideoPath = m.VideoPath,
                    TrailerPath = m.TrailerPath,
                    Summary = m.Summary,
                    Year = m.Year
                })
                .ToListAsync();

            return movieModel;
        }

        public async Task<MovieServiceModel> FindMovie(Guid id)
        {
            Movie movie = await this.Db.Movies.FindAsync(id);
            MovieServiceModel movieModel = new MovieServiceModel
            {
                Id = movie.Id,
                Name = movie.Name,
                Genres = movie.Genres,
                Rating = movie.Rating,
                PosterPath = movie.PosterPath,
                VideoPath = movie.VideoPath,
                TrailerPath = movie.TrailerPath,
                Summary = movie.Summary,
                Year = movie.Year
            };

            movieModel.Prices = await this.priceService.GetAllPricesForMovie(movieModel.Id);

            return movieModel;
        }
    }
}