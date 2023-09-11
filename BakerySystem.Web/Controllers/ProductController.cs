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
		public async Task<IActionResult> All(int id)
		{

			var products = await this.dbContext
					.Products
					.OrderByDescending(c => c.Id)
					.Where(c => c.CategoryId == id)
					 .Select(p => new ProductListingVIewModel
					 {
						 Id = id,
						 Name = p.Name,
						 Price = p.Price,
						 ImageUrl = p.ImageUrl,
						 Description = p.Description,
						 CategoryId = p.CategoryId,

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
				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				ImageUrl = product.ImageUrl,
				Description = product.Description,
				CategoryId = product.CategoryId


			};

			this.dbContext.Products.Add(productData);
			this.dbContext.SaveChanges();


			return View(RedirectToAction(nameof(All)));
		}



		private async Task<IEnumerable<ProductCategoryViewModel>> GetProductCategory()
			=> await this.dbContext
			.Categories
			.Select(c => new ProductCategoryViewModel
			{
				Id = c.Id,
				Name = c.Name,
				
			})
			.ToArrayAsync();








	}
}
