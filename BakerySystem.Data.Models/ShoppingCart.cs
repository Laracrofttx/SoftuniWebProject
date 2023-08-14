namespace BakerySystem.Data.Models
{
	public class ShoppingCart
	{
		
		public ApplicationUser User { get; set; }
		public string ShoppingCartId { get; set; }

		public DateTime DueDate { get; set; }

		public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }	



	}
}
