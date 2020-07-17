using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Dtos
{
	public class MovieDto
	{
		public int id { get; set; }
	
		public string MovieName { get; set; }
		
		public Nullable<DateTime> RealeseDate { get; set; }
		public Nullable<DateTime> AddTime { get; set; }
		
		
		public int NumberInStock { get; set; }
		
		public GenreDto Genre { get; set; }
		public int GenreId { get; set; }
	}
}