using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MovieApp.Models
{
    public class EditMovieViewModel
    {

        [DisplayName("Titel*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "VERLICHT")]
        [MaxLength(25, ErrorMessage = "Maximum 25 karakters")]
        public string Title { get; set; }


        [DisplayName("Beschrijving")]
        [MaxLength(250, ErrorMessage = "MAximum 250 karakters")]
        public string Description { get; set; }

        public string Genre { get; set; }


        [DisplayName("uitgavedatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        [Range(typeof(DateTime), "1/1/1900", "1/1/2070",
        ErrorMessage = "uitgavedatum {0} must be between {1} and {2}")]
        public DateTime ReleaseDate { get; set; }

    }
}
