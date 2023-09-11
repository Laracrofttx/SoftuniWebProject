
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

		

		public async Task<bool> CategoryExists(int categoryId)
		{ 
		
		
			return await dbContext.Categories.AnyAsync(c => c.Id == categoryId);

		
		}

		//public async Task<IActionResult> Add() => View(new CategoryViewModel
		//{


		//	Name = await this.GetCategory()


		//});


		[HttpGet]
		public async Task<IActionResult> AllCategoriesAsync(int id)
		{
			var categories = await this.dbContext
				.Categories
				.Where(c => c.Id == id)
				.Select(c => new CategoryViewModel
				{
					Id = c.Id,
					Name = c.Name

				})
				.ToArrayAsync();

			return View(categories);
		}



		[HttpPost]

		public async Task<IActionResult> AddCategory(CategoryViewModel category)
		{

			//if (!this.dbContext.Categories.Any(c => c.Id == category.Id))
			//{
			//	this.ModelState.AddModelError(nameof(category.Id), "Category does not exist");

			//}

			if (!ModelState.IsValid)
			{
				
				return View(category);
			}

			var categories = new Category
			{

				Id = category.Id,
				Name = category.Name


			};

			this.dbContext.Categories.Add(categories);
			this.dbContext.SaveChanges();

			return RedirectToAction("Index", "Home");

		}

		private async Task<IEnumerable<CategoryViewModel>> GetCategory()
			=> await this.dbContext
			.Categories
			.Select(c => new CategoryViewModel
			{
				Id = c.Id,
				Name = c.Name,

			})
			.ToArrayAsync();


	}



}
