namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Order;
	public class OrderDetailsController : Controller
	{
		private readonly IOrderService orderService;

		public OrderDetailsController(IOrderService orderService)
		{
			this.orderService = orderService;
		}
		public IActionResult Checkout()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Checkout(CheckoutViewModel order)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			try
			{
				await this.orderService.CheckoutOrder(order);

			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Something's wrong..");

				return View(order);
			}

			return RedirectToAction("Index", "Home");


		}
	}
}
