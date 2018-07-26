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
    public class MovieController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieController()
        {
            _dbContext=new ApplicationDbContext();
        }

        //    /api/movies/
        public IEnumerable<MovieDto> Get(string query=null)
        {
            var moviesQuery = _dbContext.Movies.Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if(!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery.
                ToList()
                .Select(Mapper.Map<Movies, MovieDto>);
        }
        // api/movies/id
        public IHttpActionResult Get(int id)
        {
            var moviesInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (moviesInDb == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MovieDto>(moviesInDb));
        }

        // api/movies/
        [HttpPost]
        public IHttpActionResult Post(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movies = Mapper.Map<MovieDto, Movies>(movieDto);
            _dbContext.Movies.Add(movies);
            _dbContext.SaveChanges();

            movieDto.Id = movies.Id;

            return Created(new Uri(Request.RequestUri + "/" + movies.Id), movieDto);
        }

        // api /api/movies/ 
        [HttpPut]
        public int Edit(MovieDto movieDto, int id)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadGateway);

            var moviesInDb = _dbContext.Movies.Single(i => i.Id == id);
            if (moviesInDb == null)
               throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, moviesInDb);
            _dbContext.SaveChanges();

            return moviesInDb.Id;
        }

        // api/Delete
        [HttpDelete]
        public int Delete(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(i => i.Id == id);
            if(movieInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Movies.Remove(movieInDb);
            _dbContext.SaveChanges();
            return movieInDb.Id;
        }
    }
}
