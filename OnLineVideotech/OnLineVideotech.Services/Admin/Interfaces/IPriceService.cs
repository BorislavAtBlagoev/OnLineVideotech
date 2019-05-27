using System;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Admin.Interfaces
{
    public interface IPriceService : IBaseService
    {
        Task CreatePrice(Guid movieId, string roleId, decimal moviePrice);
    }
}