using System.Threading.Tasks;
using ImmoGest.Domain.Core.Interfaces;
using ImmoGest.Domain.Entities;

namespace ImmoGest.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
