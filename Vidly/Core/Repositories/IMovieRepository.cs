using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Domain;
using Vidly.Persistence;

namespace Vidly.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetSingleWithGenre(int id);
        Movie GetSingleOrThrow(int id);
        IQueryable<Movie> QueryableWithGenre();
    }
}