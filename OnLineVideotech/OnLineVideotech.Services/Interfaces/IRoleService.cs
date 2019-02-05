using OnLineVideotech.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles();
    }
}