using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Core.Domain;
using Vidly.Core.Repositories;

namespace Vidly.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Customer GetSingleWithMembershipType(int id)
        {
            return ApplicationDbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        }

        public Customer GetSingleOrThrow(int id)
        {
            return ApplicationDbContext.Customers.Single(c => c.Id == id);
        }

        public IQueryable<Customer> QueryableWithMembershipType()
        {
            return ApplicationDbContext.Customers.Include(c => c.MembershipType);
        }

    }
}