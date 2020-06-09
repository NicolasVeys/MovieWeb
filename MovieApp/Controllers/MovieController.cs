using Microsoft.AspNetCore.Mvc;
using MovieApp.Database;
using MovieApp.Domein;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Controllers
{
    public class MovieController : Controller
    {

        private readonly IMovieDatabase _movieDatabase;
        public MovieController(IMovieDatabase movieDatabase)
        {
            _movieDatabase = movieDatabase;
        }
        public IActionResult Index()
        {
            IEnumerable<Movie> moviesFromDb = _movieDatabase.GetMovies();
            List<MovieListViewModel> movies = new List<MovieListViewModel>();
            foreach (Movie movie in moviesFromDb)
            {
                movies.Add(new MovieListViewModel() { Id = movie.Id, Title = movie.Title });
            }
            return View(movies);
        }
        public IActionResult Detail(int id)
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);
            MovieDetailViewModel movie = new MovieDetailViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                ReleaseDate = movieFromDb.ReleaseDate,
                Genre = movieFromDb.Genre
            };
            return View(movie);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateViewModel NewMovie) {

            if (!TryValidateModel(NewMovie))
            {
                return View(NewMovie);
            }
            _movieDatabase.Insert(new Movie
            {
                Title = NewMovie.Title,
                Description = NewMovie.Description,
                Genre = NewMovie.Genre,
                ReleaseDate = NewMovie.ReleaseDate
            });
            return RedirectToAction("index");


        }
        public IActionResult Edit(int id) 
        {
            Movie movieFromDb = _movieDatabase.GetMovie(id);
            EditMovieViewModel vm = new EditMovieViewModel()
            {
                Title = movieFromDb.Title,
                Description = movieFromDb.Description,
                Genre = movieFromDb.Genre,
                ReleaseDate = movieFromDb.ReleaseDate
            };
            return View(vm);

        }

        [HttpPost]
        public IActionResult Edit(int id, EditMovieViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }

            Movie domainMovie = new Movie()
            {
                Id = id,
                Title = vm.Title,
                Description = vm.Description,
                Genre = vm.Genre,
                ReleaseDate = vm.ReleaseDate,
            };
            _movieDatabase.Update(id, domainMovie);

            return RedirectToAction("detail", new {Id = id});


        }


    }
}
