using OnLineVideotech.Data;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IBaseService
    {
        Task SaveChanges();
        OnLineVideotechDbContext Db { get; }
    }
}