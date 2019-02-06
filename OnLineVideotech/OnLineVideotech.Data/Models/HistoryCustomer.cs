using System;

namespace OnLineVideotech.Data.Models
{
    public class HistoryCustomer
    {
        public Guid HistoryId { get; set; }

        public History History { get; set; }

        public string CustomerId { get; set; }

        public User Customer { get; set; }
    }
}