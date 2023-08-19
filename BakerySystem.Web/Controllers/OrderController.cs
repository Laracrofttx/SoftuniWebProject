namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Order;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class OrderController : Controller
	{
		private readonly IOrderService orderService;

		public OrderController(IOrderService orderService)
		{
			this.orderService = orderService;
			Order order = new Order();
		}

		public async Task<IActionResult> Make()
		{
			IEnumerable<OrderViewModel> orders =
			await this.orderService.Order();

			return View(orders);
		}

		
	}
}
