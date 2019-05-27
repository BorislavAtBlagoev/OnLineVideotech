using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Admin.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Admin.Implementations
{
    public class RoleService : BaseService, IBaseService, IRoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(
            RoleManager<Role> roleManager,
            UserManager<User> userManager, 
            OnLineVideotechDbContext db) : base(db)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            IEnumerable<Role> roles = await this.roleManager.Roles.ToListAsync();

            return roles;
        }
    }
}