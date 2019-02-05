using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Implementations
{
    public class PriceService : BaseService, IBaseService, IPriceService
    {
        public PriceService(OnLineVideotechDbContext db) : base(db)
        {
        }

        public async Task CreatePrice(Movie movie, Role role, decimal moviePrice)
        {
            Price price = new Price
            {
               MovieId = movie.Id,
               RoleId = role.Id,
               MoviePrice = moviePrice
            };

            this.Db.Add(price);
            await base.SaveChanges();
        }
    }
}