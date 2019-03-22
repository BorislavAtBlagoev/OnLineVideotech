using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Models;
using OnLineVideotech.Services.Implementations;
using OnLineVideotech.Services.Interfaces;

namespace OnLineVideotech.Services.Admin.Interfaces
{
    public class MovieManagementService : BaseService, IBaseService, IMovieManagementService
    {
        private readonly IPriceService priceService;
        private readonly IGenreMovieService genreMovieService;

        public MovieManagementService(OnLineVideotechDbContext db,
            IPriceService priceService,
            IGenreMovieService genreMovieService) : base(db)
        {
            this.priceService = priceService;
            this.genreMovieService = genreMovieService;
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
                Summary = summary
            };

            this.Db.Add(movie);

            foreach (PriceServiceModel price in prices)
            {
                await this.priceService.CreatePrice(movie.Id, price.RoleId, price.Price);
            }

            foreach (GenreServiceModel genre in genres)
            {
                if (genre.IsSelected)
                {
                    await genreMovieService.Create(movie.Id, genre.Id);
                }
            }

            await base.SaveChanges();
        }
    }
}