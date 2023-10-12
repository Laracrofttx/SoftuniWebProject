namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
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

		//public async Task<IActionResult> Category()
		//{
		//	var categories = await this.dbContext
		//		.Categories
		//		.OrderBy(c => c.Id)
		//		.ToArrayAsync();
			

		//	IEnumerable<Category> category = await this.dbContext.Categories.ToArrayAsync();
		//	return View(categories);
		
		//}


		[HttpGet]
		public async Task<IActionResult> Create()
		{
			
			return View();

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

		


	}



}
