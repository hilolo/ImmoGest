using ImmoGest.Application.DTOs.User;
using ImmoGest.Domain.Entities;
using ImmoGest.Domain.Repositories;
using ImmoGest.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ImmoGest.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

       
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<User> GetByIdCompany(Guid id)
        {
            return await DbSet
                     .AsNoTracking()
                     .Include(e => e.Office)
                     .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
