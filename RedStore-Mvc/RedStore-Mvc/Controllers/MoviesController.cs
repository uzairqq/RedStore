using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using RedStore_Mvc.Models;
using RedStore_Mvc.ViewModels;

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
            var customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "uzair"},
                new Customer() {Id = 2, Name = "laraib"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Customers = customers,
                Movies = movie
            };
            return View(viewModel);
        }






    }
}