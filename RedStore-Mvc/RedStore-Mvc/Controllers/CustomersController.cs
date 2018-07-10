using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext=new ApplicationDbContext();
        }
        // GET: Customers
        public ViewResult Index()
        {
            var customers = _dbContext.Customers.ToList();
            return View(customers);
        }
        

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}