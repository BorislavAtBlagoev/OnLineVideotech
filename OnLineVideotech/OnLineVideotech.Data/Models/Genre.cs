using System.Collections.Generic;

namespace OnLineVideotech.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GenreMovie> Movies { get; set; }
    }
}