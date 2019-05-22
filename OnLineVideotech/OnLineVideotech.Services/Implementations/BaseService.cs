using OnLineVideotech.Data;
using OnLineVideotech.Services.Interfaces;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Implementations
{
    public class BaseService : IBaseService
    {
        public BaseService(OnLineVideotechDbContext db)
        {
            this.Db = db;
        }

        public OnLineVideotechDbContext Db { get; }

        public async Task SaveChanges()
        {
            await this.Db.SaveChangesAsync();
        }
    }
}