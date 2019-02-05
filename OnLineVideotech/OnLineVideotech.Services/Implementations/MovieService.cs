using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Models;
using OnLineVideotech.Services.Interfaces;

namespace OnLineVideotech.Services.Implementations
{
    public class MovieService : BaseService, IBaseService, IMovieService
    {
        public MovieService(OnLineVideotechDbContext db) : base(db)
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
            List<PriceServiceModel> prices)
        {
            Movie movie = new Movie
            {
                Name = name,
                Year = year,
                Rating = rating,
                VideoPath = videoPath,
                PosterPath = posterPath,
                TrailerPath = trailerPath,
                Summary = summary
            };

            this.Db.Add(movie);
            await base.SaveChanges();
        }
    }
}