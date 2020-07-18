using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movierApp.Dtos
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