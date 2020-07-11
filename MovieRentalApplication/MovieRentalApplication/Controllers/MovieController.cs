using MovieRentalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalApplication.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
			List<Movie> movies = new List<Movie>
			{
				new Movie{id=1, MovieName="Forrest Gump"},
				new Movie{id=2,MovieName="Source Code"}
			};
            return View(movies);
        }
    }
}