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
			var customer = db.Customers.Include(c=>c.MembershipType).SingleOrDefault(a => a.id == id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			else
			{
				return View(customer);
			}
		}
		public ActionResult New()
		{
			ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "id", "Name");
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save([Bind(Exclude = "Id")]Customer customer)
		{
			var errors = ModelState.Values.SelectMany(v => v.Errors);
			if (!ModelState.IsValid)
			{
				ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "id", "Name");
				return View("New", customer);

			}
			else
			{
				if (customer.id == 0)
				{
					db.Customers.Add(customer);
				}
				else
				{
					var aCustomer = db.Customers.FirstOrDefault(c => c.id == customer.id);
					aCustomer.Name = customer.Name;
					aCustomer.BirthDate = customer.BirthDate;
					aCustomer.MembershipTypeId = customer.MembershipTypeId;
					aCustomer.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
				}
				db.SaveChanges();
				return RedirectToAction("Index", "Customer");
			}
		}
		public ActionResult Edit(int id)
		{
			var customer= db.Customers.FirstOrDefault(a => a.id==id);
			ViewBag.MembershipTypeId = new SelectList(db.MembershipTypes, "id", "Name");
			return View("New", customer);

		}

    }
}