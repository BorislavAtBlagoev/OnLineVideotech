﻿using OnLineVideotech.Data.Models;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IPriceService
    {
        Task CreatePrice(Movie movie, Role role, decimal moviePrice);
    }
}