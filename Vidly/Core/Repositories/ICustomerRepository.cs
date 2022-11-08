using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Domain;

namespace Vidly.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetSingleWithMembershipType(int id);
        Customer GetSingleOrThrow(int id);
        IQueryable<Customer> QueryableWithMembershipType();
    }
}