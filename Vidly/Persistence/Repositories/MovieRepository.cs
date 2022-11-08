using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Core.Domain;
using Vidly.Core.Repositories;

namespace Vidly.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Movie GetSingleWithGenre(int id)
        {
            return ApplicationDbContext.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
        }

        public Movie GetSingleOrThrow(int id)
        {
            return ApplicationDbContext.Movies.Single(m => m.Id == id);
        }

        public IQueryable<Movie> QueryableWithGenre()
        {
            return ApplicationDbContext.Movies.Include(m => m.Genre);
        }
    }
}