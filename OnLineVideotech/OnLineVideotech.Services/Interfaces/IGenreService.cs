using OnLineVideotech.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IGenreService : IBaseService
    {
        Task Create(string name);

        Task<List<Genre>> GetAllGenres();
    }
}