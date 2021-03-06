﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineMovieRental.Models
{
	public class Customer
	{
		public int id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		public bool IsSubscribeToNewsLetter { get; set; }
		//public MembershipType MembershipType { get; set; }
		//public int MembershipTypeId { get; set; }
		[Display(Name = "Date Of Birth")]
		//[Min18YearOfAgeIfAMember]
		public DateTime? BirthDate { get; set; }
	}
}