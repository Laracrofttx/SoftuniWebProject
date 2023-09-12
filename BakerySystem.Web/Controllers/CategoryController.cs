
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

		//private readonly ICategoryService categoryService;

		public CategoryController(BakeryDbContext dbContext, ICategoryService categoryService)
		{
			this.dbContext = dbContext;
			//this.categoryService = categoryService;
		}



		//public async Task<bool> CategoryExists(int categoryId)
		//{


		//	return await dbContext.Categories.AnyAsync(c => c.Id == categoryId);


		//}

		public IActionResult Category()
		{


			IEnumerable<Category> category = dbContext.Categories;
			return View(category);
		
		}


		[HttpGet]
		public async Task<IActionResult> Add()
		{
			
			return View();

		}



		[HttpPost]

		public async Task<IActionResult> Add(Category category)
		{

			this.dbContext.Categories.Add(category);
			this.dbContext.SaveChanges();

			return RedirectToAction("Index", "Home");

		}

		//private async Task<IEnumerable<CategoryListingViewModel>> GetCategory()
		//	=> await this.dbContext
		//	.Categories
		//	.Select(c => new CategoryListingViewModel
		//	{
		//		Id = c.Id,
		//		Name = c.Name,

		//	})
		//	.ToArrayAsync();


	}



}
