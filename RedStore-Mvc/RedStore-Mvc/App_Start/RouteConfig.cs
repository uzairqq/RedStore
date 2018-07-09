using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RedStore_Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // if defining a customer route then should remember the order of routes custom route first and then default route
            routes.MapRoute("MoviesByReleasedDate",  //name of the route
                "movies/released/{year}/{month}", //path of the route 
                new {controller = "Movies", action = "ByReleaseDate"},  //controller and action of route
                //new {year=@"\d{4}",month=@"\d{2}"} //validations of 4 digits of year and 2 digits of month
            new {year=@"2015|2016",month=@"\d{2}"}   //validations of only 2015 and 2016 with digits months
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
