using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = GetMovies();
           
           return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }


        private IEnumerable<Movies> GetMovies()
        {
            return new List<Movies>
            {
                new Movies { Id = 1, Name = "Avengers Infinitys" },
                new Movies { Id = 2, Name = "Sanju" }
            };
        }




    }
}