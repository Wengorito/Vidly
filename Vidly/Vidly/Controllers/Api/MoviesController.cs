using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using Vidly.Persistence;
using Vidly.Core;
using Vidly.Core.Domain;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
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

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _unitOfWork.Movies.QueryableWithGenre();

            if (!query.IsNullOrWhiteSpace())
            {
                moviesQuery = moviesQuery
                    .Where(m => m.Name.Contains(query))
                    .Where(m => m.NumberAvailable > 0);
            }

            var movieDtos = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }


        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _unitOfWork.Movies.Get(id);

            if (movie == null)
                NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            movie.NumberAvailable = movie.NumberInStock;

            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _unitOfWork.Movies.Get(id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _unitOfWork.Complete();

            return Ok();
        }


        // DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMoviesAndCustomers)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _unitOfWork.Movies.Get(id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.Movies.Remove(movieInDb);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
