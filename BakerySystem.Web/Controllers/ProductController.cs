namespace BakerySystem.Web.Controllers
{
	using System.Collections.Generic;
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.ActionConstraints;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using Microsoft.EntityFrameworkCore;

	public class ProductController : Controller
	{
		private readonly BakeryDbContext dbContext;


		private readonly IProductService productService;
		private readonly ICategoryService categoryService;
		public ProductController(BakeryDbContext dbContext, IProductService productService, ICategoryService categoryService)
		{
			this.dbContext = dbContext;
			this.productService = productService;
			this.categoryService = categoryService;
		}

		public async Task<IActionResult> Add() => View(new ProductViewModel
		{


			Categories = await this.GetProductCategory()


		});


		[HttpGet]
		public async Task<IActionResult> All()
		{

			var products = await this.dbContext
					.Products
					.OrderByDescending(p => p.Id)
					 .Select(p => new ProductListingVIewModel
					 {

						 Id = p.Id,
						 Name = p.Name,
						 Price = p.Price,
						 ImageUrl = p.ImageUrl,
						 Description = p.Description


					 })
					 .ToArrayAsync();


			return View(products);

		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductViewModel product)
		{
			if (!this.dbContext.Categories.Any(c => c.Id == product.CategoryId))
			{
				this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist");

			}


			if (!ModelState.IsValid)
			{
				product.Categories = await this.GetProductCategory();

				return View(product);
			}

			var productData = new Product
			{

				Name = product.Name,
				Price = product.Price,
				ImageUrl = product.ImageUrl,
				Description = product.Description,
				CategoryId = product.CategoryId,


			};

			this.dbContext.Products.Add(productData);
			this.dbContext.SaveChanges();
				

			return RedirectToAction(nameof(All));
		}

		

		private async Task<IEnumerable<ProductCategoryViewModel>> GetProductCategory()
			=> await this.dbContext
			.Categories
			.Select(c => new ProductCategoryViewModel
			{
				Id = c.Id,
				Name = c.Name,

			})
			.ToListAsync();



		//public async Task<IActionResult> All()
		//{

		//	IEnumerable<ProductListingVIewModel> products =
		//		  await this.productService.All();

		//	return View(products);
		//}


		//public async Task<IActionResult> EasterBread()
		//{

		//	IEnumerable<ProductViewModel> easterBreadViewModel =
		//		  await this.productService.AllEasterBreads();

		//	return View(easterBreadViewModel);

		//}





	}
}
