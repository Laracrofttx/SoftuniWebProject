namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Services.Interfaces;

	public class DailyOfferController : Controller
	{
		private readonly IDailyOfferService dailyOfferService;


		public DailyOfferController(IDailyOfferService dailyOfferService)
		{
			this.dailyOfferService = dailyOfferService;
		}

		[HttpGet]
		public async Task<IActionResult> DailyOffer()
		{
			var dailyOffer = await this.dailyOfferService.DailyOffer();

			return View(dailyOffer);
		}
	}
}
