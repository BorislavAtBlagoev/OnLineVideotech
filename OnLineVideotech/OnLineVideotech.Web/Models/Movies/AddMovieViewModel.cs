using OnLineVideotech.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Web.Models.Movies
{
    public class AddMovieViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public string VideoPath { get; set; }

        [Required]
        public string PosterPath { get; set; }

        [Required]
        public string TrailerPath { get; set; }

        [Required]
        public string Summary { get; set; }

        public int PriceId { get; set; }

        public Price Price { get; set; }
    }
}