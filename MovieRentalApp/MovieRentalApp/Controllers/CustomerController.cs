using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace MovieRentalApp.Controllers
{
    public class CustomerController : Controller
    {
		private ProjectDbContext db = new ProjectDbContext();
        // GET: Customer
        public ActionResult Index()
        {
			var customers = db.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
		//[Route("")]
		public ActionResult Details(int id)
		{
			var customer = db.Customers.SingleOrDefault(a => a.id == id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			else
			{
				return View(customer);
			}
		}
    }
}