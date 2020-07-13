using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;
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
    }
}