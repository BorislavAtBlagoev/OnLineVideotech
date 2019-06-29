using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Implementations
{
    public class HistoryService : BaseService, IBaseService, IHistoryService
    {
        public HistoryService(OnLineVideotechDbContext db) : base(db)
        {
        }

        public async Task<List<HistoryServiceModel>> GetHistory()
        {
            return await this.Db.Histories
                .Include(m => m.Movie)
                .Include(u => u.Customer)
                .Select(p => new HistoryServiceModel
                {
                    Id = p.Id,
                    MovieName = p.Movie.Name,
                    CustomerName = p.Customer.UserName,
                    Price = p.Price
                })
                .ToListAsync();
        }

        public async Task<List<HistoryServiceModel>> GetHistoryForMovie(Guid movieId)
        {
            return await this.Db.Histories
                .Where(x => x.MovieId == movieId)
                .Include(m => m.Movie)
                .Include(u => u.Customer)
                .Select(p => new HistoryServiceModel
                {
                    Id = p.Id,
                    MovieName = p.Movie.Name,
                    CustomerName = p.Customer.UserName,
                    Price = p.Price
                })
                .ToListAsync();
        }

        public async Task<HistoryServiceModel> GetHistoryForMovieAboutUser(string userId, Guid movieId)
        {
            History history = await this.Db.Histories
                .SingleOrDefaultAsync(x => x.CustomerId == userId && x.MovieId == movieId);

            return new HistoryServiceModel
            {
                Id = history.Id,
                MovieName = history.Movie.Name,
                CustomerName = history.Customer.UserName,
                Price = history.Price
            };
        }
    }
}
