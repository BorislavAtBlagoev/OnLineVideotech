using OnLineVideotech.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IMovieService
    {
        Task Create(
            string name, 
            DateTime year, 
            double rating, 
            string videoPath, 
            string posterPath, 
            string trailerPath, 
            string summary,
            List<PriceServiceModel> prices);

        Task SaveChanges();
    }
}