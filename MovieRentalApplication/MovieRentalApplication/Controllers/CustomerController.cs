using MovieRentalApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRentalApplication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
			List<Customer> Customers = new List<Customer> {
				new Customer { id=1, Name="Customer 1"},
				new Customer{id=2,Name="Customer 2"}

			};

            return View(Customers);
        }
    }
}