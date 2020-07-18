using AutoMapper;
using movierApp.Dtos;
using movierApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace movierApp.Controllers.Api
{
    public class MoviesController : ApiController
    {
		private ApplicationDbContext db = new ApplicationDbContext();

		//GET/api/Moives
		public IHttpActionResult GetMovies()
		{
			var movieDto = db.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
			return Ok(movieDto);
		}

		//Get/api/Movies/1
		public IHttpActionResult GetMovie(int id)
		{
			var movie = db.Movies.SingleOrDefault(m => m.id == id);
			if (movie == null)
			{
				return NotFound();
			}
			return Ok(Mapper.Map<Movie, MovieDto>(movie));

		}
		//POST/api/Movies
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto movieDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			db.Movies.Add(movie);
			db.SaveChanges();
			return Created(new Uri(Request.RequestUri + "/" + movie.id), movieDto);
		}

		//PUT/api/Movies/1
		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var movieInDb = db.Movies.SingleOrDefault(m => m.id == id);
			if (movieInDb == null)
			{
				return NotFound();
			}
			Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
			db.SaveChanges();
			return Ok();


		}
		//DELETE/api/movie/1
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var movieInDb = db.Movies.SingleOrDefault(m => m.id == id);
			if (movieInDb == null)
			{
				return NotFound();
			}
			db.Movies.Remove(movieInDb);
			db.SaveChanges();
			return Ok();
		}


	}
}

