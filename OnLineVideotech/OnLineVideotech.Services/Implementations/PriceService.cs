using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Implementations
{
    public class PriceService : BaseService, IBaseService, IPriceService
    {
        public PriceService(OnLineVideotechDbContext db) : base(db)
        {
        }

        public async Task CreatePrice(Guid movieId, string roleId, decimal moviePrice)
        {
            Price price = new Price
            {
               MovieId = movieId,
               RoleId = roleId,
               MoviePrice = moviePrice
            };

            await this.Db.AddAsync(price);           
        }
    }
}