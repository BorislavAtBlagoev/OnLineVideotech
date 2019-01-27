using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineVideotech.Data.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MoviePrice { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}