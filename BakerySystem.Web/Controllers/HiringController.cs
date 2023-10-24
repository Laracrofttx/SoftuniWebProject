namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.JoinUs;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

	public class HiringController : Controller
	{
		private readonly IPossitionService possitionService;
        public HiringController(IPossitionService possitionService)
        {
				this.possitionService = possitionService;
        }

		[HttpGet]
        public async Task<IActionResult> Add()
		{

			return View();

		}

		[HttpPost]
		public async Task<IActionResult> Add(PossitionFormModel possition)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			try
			{
				await this.possitionService.AddPossitionAsync(possition);

			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occured");
				return View(possition);
			}

			return RedirectToAction("Index", "Home");
			
		}
	}
}
