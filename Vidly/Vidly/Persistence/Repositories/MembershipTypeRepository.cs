using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Domain;
using Vidly.Core.Repositories;

namespace Vidly.Persistence.Repositories
{
    public class MembershipTypeRepository : Repository<MembershipType>, IMembershipTypeRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public MembershipTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}