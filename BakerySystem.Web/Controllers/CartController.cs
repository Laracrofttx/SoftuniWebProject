
namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.ShoppingCart;
	using Microsoft.AspNetCore.Mvc;
	public class CartController : Controller
	{
		private readonly IProductService productService;
		private readonly ShoppingCartService shoppingCartService;



	}
}
