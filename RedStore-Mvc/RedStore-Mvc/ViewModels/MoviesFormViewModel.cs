using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.ViewModels
{
    public class MoviesFormViewModel
    {
        public IEnumerable<Genres> Genreses { get; set; }
        public Movies Movies { get; set; }
    }
}