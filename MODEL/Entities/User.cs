using System;
namespace MODEL.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Fullname { get; set; } = null!;
		public string Username { get; set; } = null!;
        public byte[] UserPasswordHash { get; set; } = null!;
        public byte[] UserSalt { get; set; } = null!;
    }
}

