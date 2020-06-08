using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieListViewModel
    {
        public string beschrijving { get; set; }
        public DateTime releaseDate { get; set; }
        public string Title { get; internal set; }
        public int Id { get; internal set; }
    }
}
