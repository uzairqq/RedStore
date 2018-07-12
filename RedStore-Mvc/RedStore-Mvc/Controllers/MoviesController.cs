using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using RedStore_Mvc.Models;

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

        public ActionResult New()
        {
            var genres = _dbContext.Genres.ToList();
            var viewModel = new ViewModels.MoviesFormViewModel()
            {
                Genreses = genres
            };
            return View("New",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movies movies)    //we can also pass MovieViewModel in parameter and also customer .. EF is smart to get the data of memebershiptype in customer because of relationship
        {
            try
            {
                if (movies.Id == 0)
                {
                    movies.DateAdded = DateTime.Now;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }


        // GET: Movies
        public ActionResult Index()
        {
            var movie = _dbContext.Movies.Include(i=>i.Genre).ToList();
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = _dbContext.Movies.Include(i=>i.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(i => i.Id == id);
            if (movieInDb == null)
                return HttpNotFound();

            var viewModel = new ViewModels.MoviesFormViewModel()
            {
                Movies = movieInDb,
                Genreses = _dbContext.Genres.ToList()
            };

            return View("New", viewModel);
        }
    }
}