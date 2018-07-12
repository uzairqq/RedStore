using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using RedStore_Mvc.Models;
using RedStore_Mvc.ViewModels;

namespace RedStore_Mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext=new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)  //we can also pass customerViewModel in parameter and also customer .. EF is smart to get the data of memebershiptype in customer because of relationship
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult New()
        {
            var memberShipTypes = _dbContext.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = memberShipTypes
            };
            return View(viewModel);
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _dbContext.Customers.Include(i=>i.MembershipType).ToList();
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