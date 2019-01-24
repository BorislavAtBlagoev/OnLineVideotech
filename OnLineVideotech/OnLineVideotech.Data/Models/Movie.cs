using System.Collections.Generic;

namespace OnLineVideotech.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Year { get; set; }

        public double Rating { get; set; }

        public List<GenreMovie> Genres { get; set; }
    }
}