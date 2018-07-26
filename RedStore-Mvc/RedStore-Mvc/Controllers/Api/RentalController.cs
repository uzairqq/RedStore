using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RedStore_Mvc.Dto;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.Controllers.Api
{
    public class RentalController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public RentalController()
        {
            _dbContext=new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            var customer = _dbContext.Customers.Single(i => i.Id == newRentalDto.CustomerId);

            var movies = _dbContext.Movies.Where(i => newRentalDto.MovieIds.Contains(i.Id)).ToList();

            foreach (var movie in movies)
            {
                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _dbContext.Rentals.Add(rental);
            }
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(NewRentalDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public NewRentalDto Get()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
