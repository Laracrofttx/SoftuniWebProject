using BakerySystem.Services;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.ViewModels.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductService productService;
		private readonly ShoppingCartService shoppingCartService;


		public CartController(IProductService productService)
		{
			this.productService = productService;
			this.shoppingCartService = shoppingCartService;
		}

		public IActionResult Index()
		{
			var items = shoppingCartService.GetShoppingCardItems();
			shoppingCartService.shoppingCardItems = items;

			var scViewModel = new ShoppingCartViewModel
			{

				ShoppingCart = this.shoppingCartService()
				ShoppingCartTotal = 
				
			
			}

			return View();
		}
	}
}
