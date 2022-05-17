using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImmoGest.Application.DTOs;
using ImmoGest.Application.DTOs.User;
using ImmoGest.Application.Extensions;
using ImmoGest.Application.Filters;
using ImmoGest.Application.Interfaces;
using ImmoGest.Domain.Auth;
using ImmoGest.Domain.Entities;
using ImmoGest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;


namespace ImmoGest.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userRepository.Dispose();
            }
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (user == null || !BC.Verify(password, user.Password))
            {
                return null;
            }

            return user;
        }

        public async Task<GetUserDto> CreateUser(CreateUserDto dto)
        {
            var created = _userRepository.Create(_mapper.Map<User>(dto));
            created.Password = BC.HashPassword(dto.Password);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<GetUserDto>(created);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            await _userRepository.Delete(id);
            return await _userRepository.SaveChangesAsync() > 0;
        }

        public async Task<GetUserDto> UpdatePassword(Guid id, UpdatePasswordDto dto)
        {
            var originalUser = await _userRepository.GetById(id);
            if (originalUser == null) return null;

            originalUser.Password = BC.HashPassword(dto.Password);
            _userRepository.Update(originalUser);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<GetUserDto>(originalUser);
        }

        public async Task<PaginatedList<GetUserDto>> GetAllUsers(GetUsersFilter filter)
        {
            filter ??= new GetUsersFilter();
            var users = _userRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter.Email), x => EF.Functions.Like(x.Email, $"%{filter.Email}%"))
                .WhereIf(filter.IsAdmin, x => x.Role == Roles.Admin)
                .Where(x => x.OfficeId == filter.OfficeId);
            return await _mapper.ProjectTo<GetUserDto>(users).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize);
        }

        public async Task<GetUserDto> GetUserById(Guid id)
        {
            return _mapper.Map<GetUserDto>(await _userRepository.GetById(id));
        }
    }
}
