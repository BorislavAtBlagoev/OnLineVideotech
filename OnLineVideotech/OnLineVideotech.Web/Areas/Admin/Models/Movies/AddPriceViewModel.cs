using Microsoft.AspNetCore.Mvc.Rendering;
using OnLineVideotech.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnLineVideotech.Web.Areas.Admin.Models.Movies
{
    public class AddPriceViewModel
    {
        public Role Role { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}