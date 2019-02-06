using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;

namespace OnLineVideotech.Services.Implementations
{
    public class GenreService : BaseService, IBaseService, IGenreService
    {
        public GenreService(OnLineVideotechDbContext db) : base(db)
        {
        }

        public async Task Create(string name)
        {
            Genre genre = new Genre()
            {
                Name = name
            };

            await this.Db.AddAsync(genre);
            await base.SaveChanges();
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await this.Db.Genres.ToListAsync();
        }
    }
}