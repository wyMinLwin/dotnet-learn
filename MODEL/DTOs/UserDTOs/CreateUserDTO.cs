using System;
namespace MODEL.DTOs.UserDTOs
{
	public class CreateUserDTO
	{
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

