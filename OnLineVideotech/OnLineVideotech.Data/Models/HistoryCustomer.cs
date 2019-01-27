using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Data.Models
{
    public class HistoryCustomer
    {
        [Key]
        public int HistoryId { get; set; }

        public History History { get; set; }

        [Key]
        public string CustomerId { get; set; }

        public User Customer { get; set; }
    }
}