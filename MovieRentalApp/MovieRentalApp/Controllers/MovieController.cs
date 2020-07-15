using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace MovieRentalApp.Controllers
{
    public class MovieController : Controller
    {
		private ProjectDbContext db = new ProjectDbContext();
		// GET: Movie
		public ActionResult Index()
        {
			var movies = db.Movies.Include(a => a.Genre).ToList();
            return View(movies);
        }
		public ActionResult Details(int id)
		{
			var movies = db.Movies.Include(c=>c.Genre).FirstOrDefault(a => a.id == id);
			return View(movies);
		}
		public ActionResult Create()
		{
			ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName");
			ViewBag.IsNew = true;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Movie movie)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName");
			
				return View("Create", movie);

			}
			if (movie.id == 0)
			{
				db.Movies.Add(movie);
			}
			else
			{
				var aMovie = db.Movies.FirstOrDefault(c => c.id == movie.id);
				aMovie.MovieName = movie.MovieName;
				aMovie.GenreId = movie.GenreId;
				aMovie.RealeseDate = movie.RealeseDate;
				aMovie.NumberInStock = movie.NumberInStock;
			}
			
			db.SaveChanges();
			return RedirectToAction("Index", "Movie");
		}
		public ActionResult Edit(int id)
		{
			var movie = db.Movies.FirstOrDefault(a => a.id == id);
			ViewBag.IsNew = false;
			ViewBag.GenreId = new SelectList(db.Genres, "id", "GenreName");
			return View("Create", movie);

		}
	}
}