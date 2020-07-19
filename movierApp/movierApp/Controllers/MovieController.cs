using movierApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace movierApp.Controllers
{
    public class MovieController : Controller
    {
		// GET: Movie
		private ApplicationDbContext db = new ApplicationDbContext();
		// GET: Movie
		public ActionResult Index()
		{
			if(User.IsInRole(RoleName.CanManageMovies))
			    return View("List");
			return View("ReadOnlyList");
		}
		public ActionResult Details(int id)
		{
			var movies = db.Movies.Include(c => c.Genre).FirstOrDefault(a => a.id == id);
			return View(movies);
		}
		[Authorize(Roles =RoleName.CanManageMovies)]
		public ActionResult Create()
		{
			ViewBag.GenreId = new SelectList(db.Genres, "Id", "GenreName");
			ViewBag.IsNew = true;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Exclude = "Id")]Movie movie)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);
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
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int id)
		{
			var movie = db.Movies.FirstOrDefault(a => a.id == id);
			ViewBag.IsNew = false;
			ViewBag.GenreId = new SelectList(db.Genres, "id", "GenreName");
			return View("Create", movie);

		}
	}
}