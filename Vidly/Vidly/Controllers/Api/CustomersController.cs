using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using System.Data.Entity;
using Vidly.Persistence;
using Vidly.Core.Domain;
using Vidly.Core;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
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


        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _unitOfWork.Customers.QueryableWithMembershipType();

            if (!string.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // POST /api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customer/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult UpdateCustomer(CustomerDto customerDto, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _unitOfWork.Customers.Get(id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _unitOfWork.Complete();

            return Ok();
        }


        // DELETE /api/customer/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _unitOfWork.Customers.Get(id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.Customers.Remove(customerInDb);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
