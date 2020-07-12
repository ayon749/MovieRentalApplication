using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
	public class Customer
	{
		public int id { get; set; }
		public string Name { get; set; }
		public bool IsSubscribeToNewsLetter { get; set; }
		public MembershipType MembershipType { get; set; }
		public int MembershipTypeId { get; set; }
	}
}