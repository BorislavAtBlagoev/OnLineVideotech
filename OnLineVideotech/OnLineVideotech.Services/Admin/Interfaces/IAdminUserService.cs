using OnLineVideotech.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Admin.Interfaces
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();
    }
}