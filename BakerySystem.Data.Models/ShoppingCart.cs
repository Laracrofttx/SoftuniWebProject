namespace BakerySystem.Data.Models
{
	public class ShoppingCart
	{
		
		public string Id { get; set; } = null!;

		public int Amount { get; set; }

		public Product Products { get; set; } = null!;



	}
}
