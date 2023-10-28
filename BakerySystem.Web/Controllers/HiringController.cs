namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.JoinUs;
	using Microsoft.AspNetCore.Mvc;

	public class HiringController : Controller
	{
		private readonly IPossitionService possitionService;
		private readonly IBufferedFileUploadService bufferedFileUploadService;

		public HiringController(IPossitionService possitionService, IBufferedFileUploadService bufferedFileUploadService)
		{
			this.possitionService = possitionService;
			this.bufferedFileUploadService = bufferedFileUploadService;

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

		[HttpGet]

		public async Task<IActionResult> Delete(int id)
		{
			var possitionExist = await this.possitionService.ExistByIdAsync(id);

			if (!possitionExist)
			{
				this.ModelState.AddModelError(string.Empty, "Selected possition does not exist!");

				RedirectToAction("All", "Hiring");
			}

			try
			{
				PossitionDeleteViewModel possition = await this.possitionService.PossitionForDeleteByIdAsync(id);

				return View(possition);

			}
			catch (Exception)
			{
				return BadRequest();

			}


		}


		[HttpPost]

		public async Task<IActionResult> Delete(int id, PossitionDeleteViewModel possition)
		{

			bool possitionExists = await this.possitionService.ExistByIdAsync(id);

			if (!possitionExists)
			{
				ModelState.AddModelError(string.Empty, "The item you want to delete does not exist!");
			}

			try
			{
				await this.possitionService.DeletePossitionByIdAsync(id);

				return RedirectToAction("All", "Hiring");
			}
			catch (Exception)
			{
				return BadRequest();
			}

		}

		[HttpGet]
		public async Task<IActionResult> Apply()
		{

			//var appliedFor = await this.possitionService.GetPossitionIdAsync(id);

			return View();

		}


		[HttpPost]
		public async Task<IActionResult> Apply(ApplyViewModel apply)
		{

			try
			{
				await this.possitionService.Apply(apply);

			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occured!");

				return View(apply);
			}

			return RedirectToAction(nameof(All));

		}
	}
}
