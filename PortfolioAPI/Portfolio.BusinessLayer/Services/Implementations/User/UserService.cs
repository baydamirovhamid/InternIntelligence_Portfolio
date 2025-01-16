using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.BusinessLayer.DTOs;
using Portfolio.BusinessLayer.Services.Interfaces.User;
using Portfolio.DataAccessLayer.Contexts;
using Portfolio.Domain.Entities;

namespace Portfolio.BusinessLayer.Services.Implementations.User
{
    public class UserService : IUserService
    {
        private readonly List<AppUser> _users = new(); // In-memory user storage
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public UserService(List<AppUser> users, UserManager<AppUser> userManager, AppDbContext context)
        {
            _users = users;
            _userManager = userManager;
            _context = context;
        }

        public async Task<UserResponseDto> CreateUserAsync(UserDto createUserDto)
        {
            var user = new AppUser
            {
                FullName = createUserDto.FullName,
                Email = createUserDto.Email,
                DateOfBirth = createUserDto.DateOfBirth
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return await Task.FromResult(new UserResponseDto
            {
                FullName = user.FullName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                IsSuccess = true,
                Message = "User created successfully."
            });
        }

        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            var users = _users.Select(user => new UserResponseDto
            {
                FullName = user.FullName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                IsSuccess = true,
                Message = "User retrieved successfully."
            }).ToList();

            return await Task.FromResult(users);
        }
    }
}

