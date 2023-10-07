using System.ComponentModel.DataAnnotations;

namespace BakerySystem.Data.Models
{
	public class Cart
	{
		[Key]
		public int CartId { get; set; }

		public List<CartItem> ShoppingCartItems { get; set; } = null!;
	}
}
