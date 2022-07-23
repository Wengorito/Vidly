using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Domain;
using Vidly.Core.Repositories;

namespace Vidly.Persistence.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public RentalRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}