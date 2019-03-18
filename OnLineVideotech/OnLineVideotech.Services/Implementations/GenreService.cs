using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Models;
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

        public async Task<GenreServiceModel> FindGenre(Guid id)
        {
            Genre genre = await this.Db.Genres.FindAsync(id);

            return new GenreServiceModel
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public async Task<List<GenreServiceModel>> GetAllGenres()
        {
            return await this.Db.Genres
                .Select(x => new GenreServiceModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }
    }
}