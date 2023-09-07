using System;
namespace MODEL.Entities
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Code { get; set; } = null!;
		public int Price { get; set; } = 0;
	}
}

