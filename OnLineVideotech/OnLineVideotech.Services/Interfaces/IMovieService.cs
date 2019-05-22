using OnLineVideotech.Services.ServiceModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieServiceModel>> GetMovies();
    }
}