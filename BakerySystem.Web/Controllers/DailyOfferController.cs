namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using Microsoft.AspNetCore.Mvc;

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
