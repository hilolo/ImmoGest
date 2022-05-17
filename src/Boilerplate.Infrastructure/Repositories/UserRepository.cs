using ImmoGest.Domain.Entities;
using ImmoGest.Domain.Repositories;
using ImmoGest.Infrastructure.Context;

namespace ImmoGest.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
