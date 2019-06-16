using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Web.Models
{
    public class UserBalanceViewModel
    {
        [Required]
        [Range(0.01, 1000, ErrorMessage = "The amount must be between 0.001 BGN and 1000 BGN")]
        public decimal Balance { get; set; }
    }
}