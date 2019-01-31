using Microsoft.AspNetCore.Mvc.Rendering;
using OnLineVideotech.Services.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnLineVideotech.Web.Areas.Admin.Models.Users
{
    public class AdminUserListingsViewModel
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}