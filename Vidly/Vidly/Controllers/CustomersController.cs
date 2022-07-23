using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Core;
using Vidly.Core.Domain;
using Vidly.Persistence;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CustomersController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }

        // GET: Customers/Index
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMoviesAndCustomers))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var customer = _unitOfWork.Customers.GetSingleWithMembershipType(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult New()
        {
            var membershipTypes = _unitOfWork.MembershipTypes.GetAll();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult Edit(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _unitOfWork.MembershipTypes.GetAll()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel(customer)
                {
                    MembershipTypes = _unitOfWork.MembershipTypes.GetAll()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _unitOfWork.Customers.Add(customer);
            else
            {
                var customerInDb = _unitOfWork.Customers.GetSingleOrThrow(customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Customers");
        }
    }
}