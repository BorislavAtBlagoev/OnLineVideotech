using System;
using System.Collections.Generic;

namespace OnLineVideotech.Data.Models
{
    public class History
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Price { get; set; }

        public List<Movie> Movies { get; set; }

        public List<User> Customers { get; set; }
    }
}