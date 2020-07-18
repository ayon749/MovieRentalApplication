using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineMovieRental.Models
{
	public class MembershiType
	{
		public int id { get; set; }
		public string Name { get; set; }

		public int SignUpFee { get; set; }
		public int DurantionInMonths { get; set; }
		public int DiscountRate { get; set; }


		public static readonly byte Unknown = 0;
		public static readonly byte PayAsYouGo = 1;
	}
}