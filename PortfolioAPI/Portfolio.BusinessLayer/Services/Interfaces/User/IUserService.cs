using Portfolio.BusinessLayer.DTOs;
using Portfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.Services.Interfaces.User
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(UserDto userDto);
        Task<List<UserResponseDto>> GetAllUsersAsync();
    }
}
