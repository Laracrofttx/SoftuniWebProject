namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	public class Cart
	{

		[Key]
		public int CartId { get; set; }

		public List<CartItem> CartItems { get; set; } = null!;
		

	}
}
