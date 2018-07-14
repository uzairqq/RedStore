using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public IEnumerable<Customer> Get()
        {
            return _dbContext.Customers.ToList();
        }
        
        //    /api/customers/1
        public Customer Get(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if(customer==null)
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }
        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer;
        }

        //Put /api/customers
        [HttpPut]
        public int UpdateCustomer(Customer customer, int id)
        {
            if(!ModelState.IsValid)
                throw new   HttpResponseException(HttpStatusCode.BadGateway);

            var customerInDb = _dbContext.Customers.SingleOrDefault(i => i.Id == id);

            if(customerInDb==null)
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

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
