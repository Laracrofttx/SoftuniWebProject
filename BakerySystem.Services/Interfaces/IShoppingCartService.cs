namespace BakerySystem.Services.Interfaces
{
	
	using BakerySystem.Web.ViewModels.ShoppingCart;

	public interface IShoppingCartService
	{
		Task Remove(CartItemViewModel item);
	}
}
