using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace movierApp.Models
{
	public class Rental
	{
		public int id { get; set; }
		public DateTime DateRented { get; set; }
		public DateTime? DateReturned { get; set; }
		[Required]
		public  Customer Customer { get; set; }
		[Required]
		public Movie Movie { get; set; }
	}
}