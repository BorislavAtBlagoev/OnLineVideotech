using OnLineVideotech.Services.Admin.Models;
using OnLineVideotech.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IMovieManagementService : IBaseService
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
    }
}