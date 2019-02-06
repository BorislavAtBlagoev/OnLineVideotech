using System;
using System.ComponentModel.DataAnnotations;

namespace OnLineVideotech.Services.Admin.Models
{
    public class GenreServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}