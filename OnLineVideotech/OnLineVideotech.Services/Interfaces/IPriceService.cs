using OnLineVideotech.Data.Models;
using System;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IPriceService
    {
        Task CreatePrice(Guid movieId, string roleId, decimal moviePrice);
    }
}