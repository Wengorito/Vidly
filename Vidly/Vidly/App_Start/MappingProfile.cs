using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Controllers.Api;
using Vidly.Core.Domain;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Customer, CustomerDto>();

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}