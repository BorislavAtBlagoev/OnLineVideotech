using OnLineVideotech.Data.Models;
using System;

namespace OnLineVideotech.Services.ServiceModels
{
    public class HistoryServiceModel
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public string MovieName { get; set; }

        public string CustomerName { get; set; }
    }
}