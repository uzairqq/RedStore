using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using RedStore_Mvc.Dto;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Domain entity to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movies, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movies>();

        }
    }
}