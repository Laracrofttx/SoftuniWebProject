namespace BakerySystem.Web.Controllers
{
	using System.Collections.Generic;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;

	using Category = BakerySystem.Data.Models.Category;

	[Authorize]
	public class CategoryController : Controller
	{
		private readonly BakeryDbContext dbContext;

		private readonly ICategoryService categoryService;

		public CategoryController(BakeryDbContext dbContext, ICategoryService categoryService)
		{
			this.dbContext = dbContext;
			this.categoryService = categoryService;
		}



		public async Task<bool> CategoryExists(int categoryId)
		{


			return await dbContext.Categories.AnyAsync(c => c.Id == categoryId);


		}

		public async Task<IActionResult> All()
		{

			IEnumerable<CategoryListingViewModel> allCategories = await this.categoryService
				.AllCategoriesAsync();


			return View(allCategories);
		}


		[HttpGet]
		public IActionResult Create()
		{
			return this.View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Category category)
		{
			if (await this.categoryService.ExistByIdAsync(category.Id) == false)
			{
				return BadRequest();

			}

			await this.dbContext.AddAsync(category);
			await this.dbContext.SaveChangesAsync();

			return RedirectToAction("All", "Category");

		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			bool category = await this.categoryService.ExistByIdAsync(id);

			if (!category)
			{
				return RedirectToAction("All", "Category");
			}

			try
			{

				CategoryDetailsViewModel categoryModel = await this.categoryService.CategoryDetailsByIdAsync(id);

				
				return View(categoryModel);

			}
			catch (Exception)
			{

				return BadRequest();
			}


		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if (await this.categoryService.ExistByIdAsync(id) == false)
			{

				return RedirectToAction("All", "Category");

			}

			try
			{
				CategoryViewModel categoryForEdit = await this.categoryService.EditByIdAsync(id);

				return View(categoryForEdit);

			}
			catch (Exception)
			{
				return BadRequest();

			}

		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, CategoryViewModel model)
		{

			if (await this.categoryService.ExistByIdAsync(model.Id) == false)
			{

				this.ModelState.AddModelError(nameof(model.Id), "Category does not exist!");

			}

			try
			{
				await this.categoryService.EditByIdAndFormModelAsync(id, model);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Unexpected error occured!");

				return this.View(model);
			}

			return RedirectToAction("All", "Category");
		}



		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{

			bool categoryExist = await this.categoryService.ExistByIdAsync(id);

			if (!categoryExist)
			{
				return RedirectToAction("All", "Category");
			}

			try
			{
				CategoryDeleteViewModel categoryModel = await this.categoryService.DeleteByIdAsync(id);

				return View(categoryModel);

			}
			catch (Exception)
			{
				return BadRequest();
			}


		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id, CategoryDeleteViewModel model)
		{
			bool categoryExists = await this.categoryService
				.ExistByIdAsync(id);

			if (!categoryExists)
			{

				return RedirectToAction("All", "Category");

			}

			try
			{
				await this.categoryService.DeleteAsync(id);

				return RedirectToAction("All", "Category");
			}
			catch (Exception)
			{

				return BadRequest();
			}



		}

	}

}
