using OnLineVideotech.Services.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Web.Areas.Admin.Models
{
    public class AddMovieViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
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

        [Required]
        public List<PriceServiceModel> Prices { get; set; }
    }
}