using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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

        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }


        //if action parameter is this :- int movieId then  route will be:- //movies/edit?12  error in this route like :- //movies/edit/12
        //if action paramter is this :- int id then route can be this :- //movies/edit/12   erro in this route like :-  //movies/edit?12
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }


        //it will give this 12 and name parameter 
        // we can also do like this :- Movies?pageIndex=122&sortBy="laraib" to see the change
        public ActionResult Index(int? pageIndex,string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 12;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";

            return Content($"pageIndex={pageIndex} and sortBy={sortBy}");
        }

    }
}