using OnLineVideotech.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineVideotech.Services.Admin.Models
{
    public class PriceServiceModel
    {
        public string RoleId { get; set; }

        public Role Role { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}