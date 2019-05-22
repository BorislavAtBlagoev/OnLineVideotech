using OnLineVideotech.Data.Models;

namespace OnLineVideotech.Services.Admin.Models
{
    public class PriceServiceModel
    {
        public string RoleId { get; set; }

        public Role Role { get; set; }

        public decimal Price { get; set; }
    }
}