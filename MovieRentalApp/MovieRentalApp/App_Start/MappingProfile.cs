using AutoMapper;
using MovieRentalApp.Dtos;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.App_Start
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<CustomerDto, Customer>();
			Mapper.CreateMap<MembershipType, MembershipTypeDto>();
			Mapper.CreateMap<Movie, MovieDto>().ForMember(m=>m.id,opt=>opt.Ignore()); 
			Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.id, opt => opt.Ignore()); 
				
		}
	}
}