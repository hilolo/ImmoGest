using ImmoGest.Domain.Entities;
using System;
using System.Threading.Tasks;
using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.User;
using ImmoGest.Application.Filters;


namespace ImmoGest.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<User> Authenticate(string email, string password);

        Task<GetUserDto> CreateUser(CreateUserDto dto);
        Task<bool> DeleteUser(Guid id);
        Task<GetUserDto> UpdatePassword(Guid id, UpdatePasswordDto dto);
        Task<PaginatedList<GetUserDto>> GetAllUsers(GetUsersFilter filter);
        Task<GetUserDto> GetUserById(Guid id);
    }
}
