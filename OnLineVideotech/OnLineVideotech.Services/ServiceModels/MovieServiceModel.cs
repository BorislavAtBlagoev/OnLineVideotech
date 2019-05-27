using OnLineVideotech.Data.Models;
using System;
using System.Collections.Generic;

namespace OnLineVideotech.Services.ServiceModels
{
    public class MovieServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Year { get; set; }

        public double Rating { get; set; }

        public string VideoPath { get; set; }

        public string PosterPath { get; set; }

        public string TrailerPath { get; set; }

        public string Summary { get; set; }

        public List<GenreMovie> Genres { get; set; } = new List<GenreMovie>();

        public List<HistoryMovie> Histories { get; set; } = new List<HistoryMovie>();

        public List<Price> Prices { get; set; } = new List<Price>();
    }
}