using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;

namespace OnLineVideotech.Services.Implementations
{
    public class PriceService : IPriceService
    {
        private readonly OnLineVideotechDbContext db;

        public PriceService(OnLineVideotechDbContext db)
        {
            this.db = db;
        }

        public void CreatePrice(Movie movie, Role role, decimal moviePrice)
        {
            Price price = new Price
            {
               MovieId = movie.Id,
               RoleId = role.Id,
               MoviePrice = moviePrice
            };

            db.Add(price);
            db.SaveChanges();
        }
    }
}