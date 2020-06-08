using System;

namespace MovieApp.Controllers
{
    internal class MovieDetailViewModel
    {
        public MovieDetailViewModel()
        {
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
    }
}