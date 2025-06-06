﻿using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var listMovies = new List<Movie>();

            var movie1 = new Movie
            {
                Genre = "Terror",
                Id = 1,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror"
            };
            listMovies.Add(movie1);

            var movie2 = new Movie
            {
                Genre = "Terror",
                Id = 2,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror II"
            };
            listMovies.Add(movie2);

            return View(listMovies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = new Movie
            {
                Genre = "Terror",
                Id = id.Value,
                Price = 1,
                ReleaseDate = DateTime.Now,
                Title = "La noche del terror"
            };

            return View(movie);
        }
    }
}
