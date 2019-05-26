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

            await this.Db.Genres.AddAsync(genre);
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
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task UpdateGenre(GenreServiceModel genreServiceModel)
        {
            Genre genre = new Genre
            {
                Id = genreServiceModel.Id,
                Name = genreServiceModel.Name
            };

            this.Db.Genres.Update(genre);
            await this.Db.SaveChangesAsync();
        }

        public async Task Delete(GenreServiceModel genreServiceModel)
        {
            Genre genre = new Genre
            {
                Id = genreServiceModel.Id,
                Name = genreServiceModel.Name
            };

            this.Db.Genres.Remove(genre);
            await this.Db.SaveChangesAsync();
        }
    }
}