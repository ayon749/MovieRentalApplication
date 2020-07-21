using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using movierApp.Dtos;
using movierApp.Models;

namespace movierApp.Controllers.Api
{
    public class NewRentalController : ApiController
    {
	    private ApplicationDbContext db = new ApplicationDbContext();
		[HttpPost]
		public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
		{
			if (newRental.MovieIds.Count == 0)
			{
				return BadRequest("No movie id is given.");
			}
			var movies = db.Movies.Where(m => newRental.MovieIds.Contains(m.id)).ToList();

			if (movies.Count != newRental.MovieIds.Count)
			{
				return BadRequest("One or more movie Ids Invalid.");
			}
		    var customer = db.Customers.SingleOrDefault(c => c.id == newRental.CustomerId);
		    if (customer == null)
		    {
			    return BadRequest("Customer id is not valid.");
		    }
			//var customerId = newRental.CustomerId.ToString();
			foreach (var movie in movies)
		    {
				//var movie = db.Movies.FirstOrDefault(i => i.id == movieId);
				if (movie.NumberAvailable == 0)
				{
					return BadRequest("Movie is not available.");
				}
			    movie.NumberAvailable--;
			   
				Rental rental=new Rental(){Customer = customer,Movie = movie,DateRented = DateTime.Now};

				db.Rentals.Add(rental);
				db.SaveChanges();
		    }
		    db.SaveChanges();
		    return Ok();
	    }
    }
}
