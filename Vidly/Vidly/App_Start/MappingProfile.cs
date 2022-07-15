﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Controllers.Api;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
                //.ForMember(
                //    m => m.NumberAvailable,
                //    opt => opt.MapFrom(m => m.NumberInStock)
                    //);

            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}