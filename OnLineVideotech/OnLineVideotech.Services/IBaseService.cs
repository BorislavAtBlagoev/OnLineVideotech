using OnLineVideotech.Data;
using System.Threading.Tasks;

namespace OnLineVideotech.Services
{
    public interface IBaseService
    {
        Task SaveChanges();
        OnLineVideotechDbContext Db { get; }
    }
}