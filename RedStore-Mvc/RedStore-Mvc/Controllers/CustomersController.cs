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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)  //we can also pass customerViewModel in parameter and also customer .. EF is smart to get the data of memebershiptype in customer because of relationship
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _dbContext.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id==0)
            _dbContext.Customers.Add(customer);
            else
            {
                var customerInDb = _dbContext.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate= customer.BirthDate;
                customerInDb.MembershipTypeId= customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter= customer.IsSubscribedToNewsletter;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult New()
        {
            var memberShipTypes = _dbContext.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(), // i have included this there because customer id hidden is validation when using validation summary
                MembershipTypes = memberShipTypes
            };
            return View("CustomerForm",viewModel);
        }

        // GET: Customers
        public ViewResult Index()
        {
            return View();
        }
        

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}