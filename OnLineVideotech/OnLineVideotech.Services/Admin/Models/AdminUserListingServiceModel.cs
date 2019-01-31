using OnLineVideotech.Common.Mapping;
using OnLineVideotech.Data.Models;

namespace OnLineVideotech.Services.Admin.Models
{
    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}