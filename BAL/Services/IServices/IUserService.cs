using System;
using MODEL.DTOs.UserDTOs;
namespace BAL.Services.IServices
{
	public interface IUserService
	{
		Task CreateUser(CreateUserDTO request);
	}
}

