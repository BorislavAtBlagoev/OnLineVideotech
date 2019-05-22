using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Services.ServiceModels;

namespace OnLineVideotech.Services.Implementations
{
    public class MovieService : BaseService, IBaseService, IMovieService
    {
        public MovieService(OnLineVideotechDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<MovieServiceModel>> GetMovies()
        {
            return await this.Db.Movies.Select(m =>
                new MovieServiceModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Genres = m.Genres,
                    Rating = m.Rating,
                    PosterPath = m.PosterPath,
                    VideoPath = m.VideoPath,
                    TrailerPath = m.TrailerPath,
                    Summary = m.Summary,
                    Year = m.Year,
                    Roles = m.Roles
                })
                .ToListAsync();
        }
    }
}