using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Interfaces;
using OnLineVideotech.Services.Admin.ServiceModels;
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

        public async Task<List<MovieServiceModel>> GetMovies()
        {
            List<MovieServiceModel> movieModel = await this.Db.Movies
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
            Movie movie = await this.Db.Movies
                .Include(x => x.Genres)
                    .ThenInclude(p => p.Genre)
                .SingleOrDefaultAsync(m => m.Id == id);

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

        public async Task<MovieFilterServiceModel> FilteredMovies(MovieFilterServiceModel moviesModel)
        {
            MovieFilterServiceModel movieModel = new MovieFilterServiceModel();

            if (moviesModel.MovieName != null && moviesModel.Year == null && !moviesModel.Genres.Any(x => x.IsSelected))
            {
                movieModel.MovieCollection = await this.Db.Movies
                    .Include(p => p.Prices)
                      .ThenInclude(c => c.Role)
                     .Include(k => k.Prices)
                    .Where(d => d.Name.Contains(moviesModel.MovieName))
                    .Select(g => new MovieServiceModel
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Rating = g.Rating,
                        PosterPath = g.PosterPath,
                        VideoPath = g.VideoPath,
                        TrailerPath = g.TrailerPath,
                        Summary = g.Summary,
                        Year = g.Year
                    })
                    .ToListAsync();
            }
            if (moviesModel.Year != null && moviesModel.MovieName == null && !moviesModel.Genres.Any(x => x.IsSelected))
            {
                try
                {
                    movieModel.MovieCollection = await this.Db.Movies
                   .Include(p => p.Prices)
                     .ThenInclude(c => c.Role)
                    .Include(k => k.Prices)
                   .Where(d => d.Year.Year == int.Parse(moviesModel.Year))
                   .Select(g => new MovieServiceModel
                   {
                       Id = g.Id,
                       Name = g.Name,
                       Rating = g.Rating,
                       PosterPath = g.PosterPath,
                       VideoPath = g.VideoPath,
                       TrailerPath = g.TrailerPath,
                       Summary = g.Summary,
                       Year = g.Year
                   })
                   .ToListAsync();
                }
                catch (Exception)
                {
                    return movieModel;
                }
            }
            if (moviesModel.Genres.Any(x => x.IsSelected) && moviesModel.Year == null && moviesModel.MovieName == null)
            {
                //foreach (GenreServiceModel genre in moviesModel.Genres)
                //{
                //    if (genre.IsSelected)
                //    {
                //        GenreMovie genreMovie = await this.Db.GenreMovies.SingleOrDefaultAsync(x => x.GenreId == genre.Id);

                //        List<MovieServiceModel> movies = await this.Db.Movies
                //           .Include(p => p.Prices)
                //             .ThenInclude(c => c.Role)
                //            .Include(k => k.Prices)
                //            .Include(b => b.Genres)
                //                .ThenInclude(t => t.Genre)
                //           .Where(x => x.Genres.Contains(genreMovie))
                //           .Select(g => new MovieServiceModel
                //           {
                //               Id = g.Id,
                //               Name = g.Name,
                //               Rating = g.Rating,
                //               PosterPath = g.PosterPath,
                //               VideoPath = g.VideoPath,
                //               TrailerPath = g.TrailerPath,
                //               Summary = g.Summary,
                //               Year = g.Year
                //           })
                //           .ToListAsync();

                //        foreach (MovieServiceModel movie in movies)
                //        {
                //            if (!movieModel.MovieCollection.Any(m => m.Id == movie.Id))
                //            {
                //                movieModel.MovieCollection.Add(movie);
                //            }
                //        }
                //    }
                //}
            }

            return movieModel;
        }
    }
}