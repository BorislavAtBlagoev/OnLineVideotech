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
        public MovieManagementService(OnLineVideotechDbContext db) : base(db)
        {
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
    }
}