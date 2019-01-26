using System.Collections.Generic;

namespace OnLineVideotech.Data.Models
{
    public class Price
    {
        public int Id { get; set; }

        public List<Movie> Movies{ get; set; }
    }
}