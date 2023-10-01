namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Order;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class OrderController : Controller
	{
		private readonly BakeryDbContext dbContext;
		private readonly IOrderService orderService;
		private readonly IProductService productService;

		public OrderController(BakeryDbContext dbContext,IOrderService orderService, IProductService productService)
		{
			this.orderService = orderService;
			this.productService = productService;
			this.dbContext = dbContext;
		}


		public async Task<IActionResult> AddToCart(int productId)
		{

			var product = await this.dbContext
				.Products
				.FindAsync(productId);

			return View(product);


		}


	}
}
