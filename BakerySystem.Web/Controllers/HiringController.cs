﻿namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.JoinUs;

	public class HiringController : Controller
	{
		private readonly IPossitionService possitionService;
		public HiringController(IPossitionService possitionService)
		{
			this.possitionService = possitionService;
		}

		[HttpGet]
		public IActionResult Add()
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
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Remove(int id)
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
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public IActionResult Apply()
		{
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
