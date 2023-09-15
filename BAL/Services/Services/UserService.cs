using System;
using BAL.Services.IServices;
using REPOSITORY.UnitOfWork;
using AutoMapper;
using MODEL.Entities;
using MODEL.DTOs.UserDTOs;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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

		public async Task<string> LoginUser(LoginDTO request)
		{
			var user = await _unitOfWork.User.GetByCondition(u => u.Username == request.Username);
			if (user.Count() == 0)
			{
				return null;
			}
			if (!VerifyPassword(request.Password, user.First().UserPasswordHash, user.First().UserSalt))
			{
				return null;
			}
			return CreateJWTToken(user.First());
			
		}

		public string CreateJWTToken (User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name,user.Username)
			};
			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
				"myverystrongsecrectjwttoken7982139183792178938921739127@#$%**JJKJJKLJKLKJLJKLJKL"));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
			var token = new JwtSecurityToken(
				claims:claims,
				expires: DateTime.Now.AddDays(3),
				signingCredentials: creds);
			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			return jwt;
		}
		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

			}
		}

		public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computedHash.SequenceEqual(passwordHash);
			}
		}

	}
}