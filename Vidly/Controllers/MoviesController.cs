using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Vidly.Core;
using Vidly.Persistence;
using Vidly.Core.Domain;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public MoviesController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }
        
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMoviesAndCustomers))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _unitOfWork.Movies.GetSingleWithGenre(id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult New()
        {
            var genres = _unitOfWork.Genres.GetAll();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult Edit(int id)
        {
            var movie = _unitOfWork.Movies.Get(id);

            var genre = _unitOfWork.Genres.Get(id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _unitOfWork.Genres.GetAll()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _unitOfWork.Genres.GetAll()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.NumberAvailable = movie.NumberInStock;
                _unitOfWork.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _unitOfWork.Movies.GetSingleOrThrow(movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _unitOfWork.Complete();

            //return View("List");
            return RedirectToAction("Index", "Movies");
        }
    }
}