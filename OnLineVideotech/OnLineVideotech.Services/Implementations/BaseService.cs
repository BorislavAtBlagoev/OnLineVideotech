using OnLineVideotech.Data;
using OnLineVideotech.Services.Interfaces;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Implementations
{
    public class BaseService : IBaseService
    {
        private readonly OnLineVideotechDbContext db;

        public BaseService(OnLineVideotechDbContext db)
        {
            this.db = db;
        }

        public OnLineVideotechDbContext Db
        {
            get
            {
                return this.db;
            }
        }

        public async Task SaveChanges()
        {
            await this.db.SaveChangesAsync();
        }
    }
}