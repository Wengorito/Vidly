using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Core;
using Vidly.Core.Domain;
using Vidly.Dtos;
using Vidly.Persistence;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public RentalsController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public RentalsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST /api/rentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto rentalDto)
        {
            var customer = _unitOfWork.Customers.Get(rentalDto.CustomerId);

            var movies = _unitOfWork.Movies.Find(m => rentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _unitOfWork.Rentals.Add(rental);
            }

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
