using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Data.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(20)]
        public string Price { get; set; }

        public List<HistoryMovie> Movies { get; set; }

        public List<HistoryCustomer> Customers { get; set; }
    }
}