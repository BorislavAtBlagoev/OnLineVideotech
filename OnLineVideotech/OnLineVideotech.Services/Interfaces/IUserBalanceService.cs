using OnLineVideotech.Services.ServiceModels;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IUserBalanceService
    {
        Task AddAmount(UserBalanceServiceModel userModel, string userId);

        UserBalanceServiceModel GetUserBalance(string userId);

        Task DecreaseBalance(string userId, decimal amount);
    }
}