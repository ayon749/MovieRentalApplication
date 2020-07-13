using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
	public class Movie
	{
		public int id { get; set; }
		public string MovieName { get; set; }
		public DateTime RealeseDate { get; set; }
		public DateTime AddTime { get; set; }
		public int NumberInStock { get; set; }
		public Genre Genre { get; set; }
		public int GenreId { get; set; }

	}
}