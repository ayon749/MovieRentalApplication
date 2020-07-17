using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Dtos
{
	public class CustomerDto
	{
		public int id { get; set; }
	
		public string Name { get; set; }
		public bool IsSubscribeToNewsLetter { get; set; }
		
		public int MembershipTypeId { get; set; }
		public MembershipTypeDto MembershipType { get; set; }
	
		//[Min18YearOfAgeIfAMember]
		public DateTime? BirthDate { get; set; }
	}
}