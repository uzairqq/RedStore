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
            //Customer Mapping
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            //Movies Mapping
            Mapper.CreateMap<Movies, MovieDto>();
            Mapper.CreateMap<MovieDto, Movies>();

        }
    }
}