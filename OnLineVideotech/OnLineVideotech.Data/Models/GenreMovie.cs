using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Data.Models
{
    public class GenreMovie
    {
        [Key]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Key]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}