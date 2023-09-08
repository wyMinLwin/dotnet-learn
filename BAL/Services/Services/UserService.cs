using System;
using BAL.Services.IServices;
using REPOSITORY.UnitOfWork;
using AutoMapper;
using MODEL.Entities;
using MODEL.DTOs.UserDTOs;
using System.Security.Cryptography;
using System.Text;

namespace BAL.Services.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task CreateUser(CreateUserDTO request)
		{
			CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
			User UserToAdd = _mapper.Map<User>(request);
			UserToAdd.UserPasswordHash = passwordHash;
			UserToAdd.UserSalt = passwordSalt;
			if (UserToAdd != null)
			{
				await _unitOfWork.User.Add(UserToAdd);
			}
			await _unitOfWork.SaveChangesAsync();
		}

		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

			}
		}

	}
}