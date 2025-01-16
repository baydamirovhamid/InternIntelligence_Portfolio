using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.BusinessLayer.DTOs
{
    public class UserResponseDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
