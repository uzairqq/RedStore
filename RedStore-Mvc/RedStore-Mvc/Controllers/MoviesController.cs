﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using RedStore_Mvc.Models;
using RedStore_Mvc.ViewModels;

namespace RedStore_Mvc.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public MoviesController()
        {
            _dbContext=new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _dbContext.Genres.ToList();
            var viewModel = new MoviesFormViewModel()
            {
                Movies = new Movies(),
                Genreses = genres
            };
            return View("New",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movies)    //we can also pass MovieViewModel in parameter and also customer .. EF is smart to get the data of memebershiptype in customer because of relationship
        {
                if(!ModelState.IsValid)
                {
                    var viewModel = new MoviesFormViewModel
                    {
                        Movies = movies,
                        Genreses = _dbContext.Genres.ToList()
                    };
                    return View("New", viewModel);
                }

            if (movies.Id == 0)
            {
                movies.DateAdded=DateTime.Now;
                _dbContext.Movies.Add(movies);
            }
            else
                {
                    var movieInDb = _dbContext.Movies.Single(i => i.Id == movies.Id);
                    movieInDb.Name = movies.Name;
                    movieInDb.ReleaseDate= movies.ReleaseDate;
                    movieInDb.NumberInStock= movies.NumberInStock;
                    movieInDb.GenreId= movies.GenreId;
                }
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
    


        // GET: Movies
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
            
            return View("ReadOnlyListIndex");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(i=>i.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(i => i.Id == id);
            if (movieInDb == null)
                return HttpNotFound();

            var viewModel = new MoviesFormViewModel()
            {
                Movies = movieInDb,
                Genreses = _dbContext.Genres.ToList()
            };

            return View("New", viewModel);
        }
    }
}