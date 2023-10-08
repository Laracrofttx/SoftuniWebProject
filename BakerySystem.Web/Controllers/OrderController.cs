namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Order;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	public class OrderController : Controller
	{
		private readonly BakeryDbContext dbContext;
		private readonly IOrderService orderService;
		private readonly IProductService productService;

		public int ShoppingCartItemId { get; set; }
		public OrderController(BakeryDbContext dbContext, IOrderService orderService, IProductService productService)
		{
			this.orderService = orderService;
			this.productService = productService;
			this.dbContext = dbContext;
		}


		public async Task<IActionResult> Checkout()
		{

			return View();
		
		}

	}
}
