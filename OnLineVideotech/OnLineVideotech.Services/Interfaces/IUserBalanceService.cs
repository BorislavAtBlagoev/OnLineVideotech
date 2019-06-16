using OnLineVideotech.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IUserBalanceService
    {
        Task AddAmount(UserBalanceServiceModel userModel, string userId);

        UserBalanceServiceModel GetUserBalance(string userId);
    }
}