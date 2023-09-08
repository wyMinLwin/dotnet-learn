using System;
using BAL.Services.IServices;
using MODEL.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
	[ApiController]
    [Route("[controller]/api")]

    public class UserController: ControllerBase
	{
		private readonly IUserService _userService;
		public UserController (IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		public async Task<ActionResult<CreateUserDTO>> CreateUser(CreateUserDTO request)
		{
			await _userService.CreateUser(request);
			return Ok();
		}
	}
}

