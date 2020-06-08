using Microsoft.AspNetCore.Mvc;
using MovieApp.Domein;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieCreateViewModel
    {
        [DisplayName("Titel*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "VERLICHT")]
        public string Title { get; set; }

        [DisplayName("Beschrijving")]
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}