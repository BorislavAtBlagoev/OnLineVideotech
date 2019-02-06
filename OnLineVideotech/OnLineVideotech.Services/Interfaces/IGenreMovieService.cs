using System;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IGenreMovieService : IBaseService
    {
        Task Create(Guid movieId, Guid genreId);
    }
}