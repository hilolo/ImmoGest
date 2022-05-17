using ImmoGest.Domain.Entities;
using ImmoGest.Domain.Repositories;
using ImmoGest.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoGest.Infrastructure.Repositories
{
  
    public class PropertyRepository : Repository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
