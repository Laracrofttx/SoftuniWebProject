using BakerySystem.Services.Interfaces;
using BakerySystem.Web.ViewModels.Order;
using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orderService;

		public OrderController(IOrderService orderService)
		{
			this.orderService = orderService;
		}

		public async Task<IActionResult> Make()
		{
			IEnumerable<OrderViewModel> orders = 
			await this.orderService.Order();
			
			return View(orders);
		}
	}
}
