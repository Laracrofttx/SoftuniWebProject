
namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Home;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;
	using System.Collections;
	using System.Collections.Generic;
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

		[HttpGet]
		public async Task<IActionResult> AllCategoriesAsync()
		{
			var categories = await this.dbContext
				.Categories
				.Select(c => new CategoryViewModel
				{
					Id = c.Id,
					Name = c.Name


				})
				.ToArrayAsync();

			return View(categories);
		}


		//public async Task<IActionResult> AllCategoriesAsync()
		//{
		//	IEnumerable<CategoryViewModel> categoryViewModel =
		//		await this.categoryService.AllCategoriesAsync();

		//	return View(categoryViewModel);

		//}

		[HttpPost]

		public async Task<IActionResult> Add(CategoryViewModel category)
		{


			var categories = new Category
			{

				Id = category.Id,
				Name = category.Name,


			};

			 this.dbContext.Categories.Add(categories);
			 this.dbContext.SaveChanges();

			return RedirectToAction("Index", "Home");

		}


		

	}



}
