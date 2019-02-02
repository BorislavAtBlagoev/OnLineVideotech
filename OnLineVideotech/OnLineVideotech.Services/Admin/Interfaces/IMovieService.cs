using System;

namespace OnLineVideotech.Services.Admin.Interfaces
{
    public interface IMovieService
    {
        void Create(
            string name, 
            DateTime year, 
            double rating, 
            string videoPath, 
            string posterPath, 
            string trailerPath, 
            string summary,
            int priceId);
    }
}