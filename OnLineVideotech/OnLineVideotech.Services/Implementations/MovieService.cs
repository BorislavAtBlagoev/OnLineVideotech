﻿using System;
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
            //var c = this.Db.Histories.Join(this.Db.Histories,
            //    p => p.Customers.Where(x => x.CustomerId == userId),
            //    c => c.);

            return false;
        }

        public async Task BuyMovie(string userId, Guid movieId, decimal price)
        {
            await this.userBalance.DecreaseBalance(userId, price);

            History history = new History();
            history.Price = price;

            HistoryCustomer historyCustomer = new HistoryCustomer()
            {
                HistoryId = history.Id,
                CustomerId = userId
            };

            HistoryMovie historyMovie = new HistoryMovie()
            {
                HistoryId = history.Id,
                MovieId = movieId
            };

            history.Customers.Add(historyCustomer);
            history.Movies.Add(historyMovie);

            await this.Db.Histories.AddAsync(history);
            await this.Db.SaveChangesAsync();
        }
    }
}