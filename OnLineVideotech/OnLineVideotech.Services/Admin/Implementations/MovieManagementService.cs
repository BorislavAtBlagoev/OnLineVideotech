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
        private readonly IPriceService price;

        public MovieManagementService(OnLineVideotechDbContext db, IPriceService price) : base(db)
        {
            this.price = price;
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

            foreach (var item in prices)
            {
                await this.price.CreatePrice(movie.Id, item.RoleId, item.Price);                
            }

            await base.SaveChanges();
        }
    }
}