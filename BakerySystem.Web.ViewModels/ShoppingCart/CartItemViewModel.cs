namespace BakerySystem.Web.ViewModels.ShoppingCart
{
	using BakerySystem.Data.Models;
	public class CartItemViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Image { get; set; } = null!;

		public decimal Price { get; set; }

		public decimal TotalPrice { get; set; }

		public int Quantity { get; set; }


		public IEnumerable<CartItem> ShoppingCartItems { get; set; } = null!;

	}
}
