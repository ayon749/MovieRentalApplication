using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
	public class ProjectDbContext:DbContext
	{
		public DbSet<Customer>Customers { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<MembershipType> MembershipTypes { get; set; }
	}
}