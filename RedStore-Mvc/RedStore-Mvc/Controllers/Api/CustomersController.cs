using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RedStore_Mvc.Dto;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        public CustomersController()
        {
            _dbContext=new ApplicationDbContext();

        }
        //   /api/customers
        public IEnumerable<CustomerDto> Get()
        {
            return _dbContext.Customers.
                Include(i=>i.MembershipType).
                ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }
        
        //    /api/customers/1
        public IHttpActionResult Get(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }
        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //Put /api/customers
        [HttpPut]
        public int UpdateCustomer(CustomerDto customerDto, int id)
        {
            if(!ModelState.IsValid)
                throw new   HttpResponseException(HttpStatusCode.BadGateway);

            var customerInDb = _dbContext.Customers.SingleOrDefault(i => i.Id == id);

            if(customerInDb==null)
                throw  new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);
            _dbContext.SaveChanges();
            return customerInDb.Id;
        }

        // DElETE /api/customers/1
        [HttpDelete]
        public int Delete(int id)
        {
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();
            return customerInDb.Id;
        }
    }
}
