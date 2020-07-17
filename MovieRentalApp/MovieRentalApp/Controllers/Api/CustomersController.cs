using AutoMapper;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
		private ProjectDbContext db = new ProjectDbContext();

		//GET/api/Customers
		public IHttpActionResult GetCustomers()
		{
			var customerDto= db.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
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
			return Ok(Mapper.Map<Customer,CustomerDto>(customer));
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
			return Created(new Uri(Request.RequestUri+"/"+customer.id),customerDto);
		}

		//PUT/api/Customers/1
		[HttpPut]
		public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
			{
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
			var customerInDb = db.Customers.SingleOrDefault(c => c.id == id);
			if (customerInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
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
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			}
			var customerInDb = db.Customers.SingleOrDefault(c => c.id == id);
			if (customerInDb == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			db.Customers.Remove(customerInDb);
			db.SaveChanges();
			return Ok();
		}

	}
}
