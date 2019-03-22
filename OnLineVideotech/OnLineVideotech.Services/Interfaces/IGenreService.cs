using OnLineVideotech.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IGenreService : IBaseService
    {
        Task Create(string name);

        Task<List<GenreServiceModel>> GetAllGenres();

        Task<GenreServiceModel> FindGenre(Guid id);

        Task UpdateGenre(GenreServiceModel genreServiceModel);

        Task Delete(GenreServiceModel genreServiceModel);
    }
}