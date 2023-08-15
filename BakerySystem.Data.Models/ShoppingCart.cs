namespace BakerySystem.Data.Models
{
	public class ShoppingCart
	{
		public ShoppingCart()
		{
			this.ShoppingCartItems = new HashSet<ShoppingCartItem>();
		}
		public string ShoppingCartId { get; set; }

		public ICollection<ShoppingCartItem> ShoppingCartItems { get;set; }

	}
}
