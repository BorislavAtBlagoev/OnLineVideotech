using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        public RoleService(
            RoleManager<Role> roleManager,
            UserManager<User> userManager)
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