using System.Collections.Generic;

namespace OnLineVideotech.Web.Areas.Admin.Models.Movies
{
    public class MoviePriceViewModel
    {
        public AddMovieViewModel AddMovieViewModel { get; set; }

        public List<AddPriceViewModel> AddPriceViewModels { get; set; }
    }
}