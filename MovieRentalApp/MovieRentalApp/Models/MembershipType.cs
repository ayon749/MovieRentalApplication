using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
	public class MembershipType
	{
		public int id { get; set; }
		public int SignUpFee { get; set; }
		public int DurantionInMonths { get; set; }
		public int DiscountRate { get; set; }
	}
}