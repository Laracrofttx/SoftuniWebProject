namespace BakerySystem.Data.Models
{
	public class ShoppingCartItem
	{
		public int Id { get; set; }

		public Product Products { get; set; }

		public int ProductId { get; set; }

		public int Amount { get; set; }

		public string ShoppingCartId { get; set; } 
	}
}
