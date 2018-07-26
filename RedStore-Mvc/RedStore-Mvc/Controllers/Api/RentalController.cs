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
            if (newRentalDto.MovieIds.Count == 0)
                return BadRequest("No Movies Id's have been given");

            var customer = _dbContext.Customers.SingleOrDefault(i => i.Id == newRentalDto.CustomerId);
           
            if (customer == null)
                return BadRequest("Customer Id is Not Valid");

            var movies = _dbContext.Movies.Where(i => newRentalDto.MovieIds.Contains(i.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("One or More Movie Id's Are Invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

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
