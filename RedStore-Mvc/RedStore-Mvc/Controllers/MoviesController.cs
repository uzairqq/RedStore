using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movies()
            {
                Id = 1,
                Name = "Avengers"
            };
            return View(movie);
        }
    }
}