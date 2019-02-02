using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Data.Models
{
    public class HistoryMovie
    {
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int HistoryId { get; set; }

        public History History { get; set; }
    }
}