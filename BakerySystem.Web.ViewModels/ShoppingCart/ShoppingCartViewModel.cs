namespace BakerySystem.Web.ViewModels.ShoppingCart
{
	using BakerySystem.Data.Models;
	public class ShoppingCartViewModel
	{
		public CartItem ShoppingCart { get; set; } = null!;
		public decimal ShoppingCartTotal { get; set; }
	}
}
