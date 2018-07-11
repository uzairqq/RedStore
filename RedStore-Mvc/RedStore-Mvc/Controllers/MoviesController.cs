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


        




    }
}