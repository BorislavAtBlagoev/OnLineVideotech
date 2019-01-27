using System;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Interfaces;

namespace OnLineVideotech.Services
{
    public class MovieService : IMovieService
    {
        private readonly OnLineVideotechDbContext db;

        public MovieService(OnLineVideotechDbContext db)
        {
            this.db = db;
        }

        public void Create(
            string name,
            DateTime year,
            double rating,
            string videoPath,
            string posterPath,
            string trailerPath,
            string summary,
            int priceId)
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
                PriceId = priceId
            };

            this.db.Add(movie);
            this.db.SaveChanges();
        }
    }
}