﻿using OnLineVideotech.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieServiceModel>> GetMovies();
        Task<MovieServiceModel> FindMovie(Guid id);
    }
}