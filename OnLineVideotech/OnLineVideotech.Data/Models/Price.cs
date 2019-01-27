using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Data.Models
{
    public class Price
    {
        [Key]
        public int Id { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}