using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
	public class Min18YearOfAgeIfAMember: ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var custoer = (Customer)validationContext.ObjectInstance;
			if (custoer.MembershipTypeId == MembershipType.Unknown||custoer.MembershipTypeId==MembershipType.PayAsYouGo)
			{
				return ValidationResult.Success;
			}
			if (custoer.BirthDate == null)
			{
				return new ValidationResult("Birthdate is required");
				
			}
			var age = DateTime.Now.Year - custoer.BirthDate.Value.Year;
			return (age >= 18) ? ValidationResult.Success : new ValidationResult("A customer age should be at least 18 year for membership.");
		}
	}
}