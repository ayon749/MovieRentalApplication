using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace movierApp.Models
{
	public class Movie
	{
		public int id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string MovieName { get; set; }
		[Required(ErrorMessage = "Release Date is required")]
		public Nullable<DateTime> RealeseDate { get; set; }
		public Nullable<DateTime> AddTime { get; set; }
		[Required(ErrorMessage = "Availabe stock is required")]
		[Range(1, 20, ErrorMessage = "stock should be between 1 to 20")]
		public int NumberInStock { get; set; }
		public Genre Genre { get; set; }
		[Required(ErrorMessage = "Genre stock is required")]
		public int GenreId { get; set; }

		public int NumberAvailable { get; set; }
	}
}