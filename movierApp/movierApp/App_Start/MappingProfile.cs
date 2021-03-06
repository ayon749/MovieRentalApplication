﻿using AutoMapper;
using movierApp.Dtos;
using movierApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movierApp.App_Start
{
	public class MappingProfile :Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Customer, CustomerDto>();
			Mapper.CreateMap<CustomerDto, Customer>();
			Mapper.CreateMap<Movie, MovieDto>();
			Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.id, opt => opt.Ignore());
			Mapper.CreateMap<MembershipType, MembershipTypeDto>();
			Mapper.CreateMap<Genre, GenreDto>();
		}
	}
}