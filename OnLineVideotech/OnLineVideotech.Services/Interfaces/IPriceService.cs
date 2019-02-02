using OnLineVideotech.Data.Models;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IPriceService
    {
        void CreatePrice(Movie movie, Role role, decimal moviePrice);
    }
}