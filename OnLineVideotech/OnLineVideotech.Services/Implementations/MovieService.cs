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
        private IUserBalanceService userBalance;

        public MovieService(OnLineVideotechDbContext db,
            IPriceService priceService,
            IUserBalanceService userBalance) : base(db)
        {
            this.priceService = priceService;
            this.userBalance = userBalance;
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

        public bool IsPurchased(string userId, Guid movieId)
        {
            return this.Db.Histories.Any(x => x.MovieId == movieId && x.CustomerId == userId);
        }

        public async Task BuyMovie(string userId, Guid movieId, decimal price)
        {
            await this.userBalance.DecreaseBalance(userId, price);

            History history = new History();
            history.Price = price;
            history.CustomerId = userId;
            history.MovieId = movieId;
            history.Date = DateTime.Now;

            await this.Db.Histories.AddAsync(history);
            await this.Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieServiceModel>> GetAllPurchasedMoviesForUser(string userId)
        {
            List<History> userHistories = await this.Db.Histories.Where(x => x.CustomerId == userId).ToListAsync();
            List<MovieServiceModel> movies = new List<MovieServiceModel>();

            foreach (History history in userHistories)
            {
               Movie movie = await this.Db.Movies
                    .FindAsync(history.MovieId);

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

                movies.Add(movieModel);
            }

            return movies;
        }
    }
}