using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Services.Admin.Interfaces;
using OnLineVideotech.Services.Admin.ServiceModels;

namespace OnLineVideotech.Services.Admin.Implementations
{
    public class AdminUserService : BaseService, IBaseService, IAdminUserService
    {
        public AdminUserService(OnLineVideotechDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
        {
            return await this.Db
                   .Users
                   .Select(x => new AdminUserListingServiceModel
                   {
                       Id = x.Id,
                       Email = x.Email
                   })
                   .ToListAsync();
        }
    }
}