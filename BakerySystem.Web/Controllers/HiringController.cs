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


		[HttpGet]
		public async Task<IActionResult> All()
		{

			var allPossitions = await this.possitionService
				.GetAllPossitionsAsync();

			return View(allPossitions);

		}


		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{

			var jobDetails = await this.possitionService
				.PossitionDetailsAsync(id);

			return View(jobDetails);
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (await this.possitionService.ExistByIdAsync(id) == false)
			{
				return RedirectToAction(nameof(All));
			}

			try
			{
				PossitionFormModel productForEdit = await this.possitionService.GetPossitionForEditByIdAsync(id);

				return View(productForEdit);

			}
			catch (Exception)
			{
				return BadRequest();
			}

		}


		[HttpPost]
		public async Task<IActionResult> Edit(int id, PossitionFormModel possition)
		{

			if (await this.possitionService.ExistByIdAsync(id) == false)
			{
				return RedirectToAction(nameof(All));
			}

			try
			{

				await this.possitionService.EditPossitionByIdAndFormModelAsync(id, possition);

			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occured!");

				return View(possition);
			}


			return RedirectToAction(nameof(All));
		}
	}
}
