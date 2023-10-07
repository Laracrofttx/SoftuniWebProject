using System.ComponentModel.DataAnnotations;

namespace BakerySystem.Data.Models
{
	public class CartItem
	{
		[Key]
		public int CartItemId { get; set; }

		public int CartId { get; set; }

		public string ProductName { get; set; } = null!;

		public decimal Price { get; set; }

		public string Image { get; set; } = null!;

		public int Quantity { get; set; }

		public decimal TotalAmount { get; set; }

		public int ProductId { get; set; }

		public virtual Product Products { get; set; } = null!;
	}
}
