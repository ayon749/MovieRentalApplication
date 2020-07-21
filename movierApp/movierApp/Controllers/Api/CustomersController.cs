using movierApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AutoMapper;
using movierApp.Dtos;

namespace movierApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
		private ApplicationDbContext db = new ApplicationDbContext();

		//GET/api/Customers
		public IHttpActionResult GetCustomers(string query=null)
		{
			var customersQuery = db.Customers.Include(c => c.MembershipType);
			if (!string.IsNullOrWhiteSpace(query))
			{
				customersQuery = customersQuery.Where(c => c.Name.Contains(query));
			}
				
			var customerDto=customersQuery.Select(Mapper.Map<Customer, CustomerDto>);
			return Ok(customerDto);
		}
		//GET/api/Customers/1
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = db.Customers.SingleOrDefault(c => c.id == id);
			if (customer == null)
			{
				return NotFound();
			}
			return Ok(Mapper.Map<Customer, CustomerDto>(customer));
		}
		//Post/api/Customers
		//[HttpPost]
		//public Customer PostCustomer(Customer customer)
		//{

		//}
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
			db.Customers.Add(customer);
			db.SaveChanges();
			customerDto.id = customer.id;
			return Created(new Uri(Request.RequestUri + "/" + customer.id), customerDto);
		}

		//PUT/api/Customers/1
		[HttpPut]
		public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var customerInDb = db.Customers.SingleOrDefault(c => c.id == id);
			if (customerInDb == null)
			{
				return NotFound();
			}
			Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

			db.SaveChanges();

			return Ok();


		}

		//DELETE/api/Customers/1
		[HttpDelete]
		public IHttpActionResult DeleteCustomer(int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var customerInDb = db.Customers.SingleOrDefault(c => c.id == id);
			if (customerInDb == null)
			{
				return NotFound();
			}
			db.Customers.Remove(customerInDb);
			db.SaveChanges();
			return Ok();
		}
	}
}
