using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Services.Admin.Interfaces;
using OnLineVideotech.Services.Admin.Models;

namespace OnLineVideotech.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly OnLineVideotechDbContext db;

        public AdminUserService(OnLineVideotechDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
            => await this.db
                   .Users
                   .Select(x => new AdminUserListingServiceModel
                   {
                       Id = x.Id,
                       Email = x.Email
                   })
                   .ToListAsync();

        public async void SaveChanges()
        {
            await this.db.SaveChangesAsync();
        }
    }
}