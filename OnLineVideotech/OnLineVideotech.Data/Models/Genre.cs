using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Data.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<GenreMovie> Movies { get; set; } = new List<GenreMovie>();
    }
}