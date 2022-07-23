using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core;
using Vidly.Core.Repositories;
using Vidly.Persistence.Repositories;

namespace Vidly.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Customers = new CustomerRepository(_context);
            Genres = new GenreRepository(_context);
            MembershipTypes = new MembershipTypeRepository(_context);
            Rentals = new RentalRepository(_context);
        }

        public IMovieRepository Movies { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IGenreRepository Genres { get; private set; }

        public IMembershipTypeRepository MembershipTypes { get; private set; }

        public IRentalRepository Rentals { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}