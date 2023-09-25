namespace BakerySystem.Web.Controllers
{

	using System.Collections.Generic;
	using System.Xml.Linq;
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;

	public class ProductController : Controller
	{
		private readonly BakeryDbContext dbContext;


		private readonly IProductService productService;
		private readonly ICategoryService categoryService;
		public MainLayoutViewModel MainLayoutViewModel { get; set; } = null!;



		public ProductController(BakeryDbContext dbContext, IProductService productService, ICategoryService categoryService)
		{
			this.dbContext = dbContext;
			this.productService = productService;
			this.categoryService = categoryService;



			this.MainLayoutViewModel = new MainLayoutViewModel();
			this.MainLayoutViewModel.pageTitle = "Products";

			this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;
		}

		

		public async Task<IActionResult> Add() => View(new ProductFormModel
		{

			Categories = await this.categoryService.GetProductCategoryAsync()

		});


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{

			var product = await this.dbContext
				.Products
				.FindAsync(id);
				




			if (await this.productService.ExistByIdAsynch(id) == false)
			{
				return RedirectToAction("All", "Product");

			}

			var productModel = await this.productService
				.ProductForEditByIdAsync(id);

			productModel.Categories = await this.categoryService.GetProductCategoryAsync();


			return View(new ProductFormModel()
			{
				Id = productModel.Id,
				Name = productModel.Name,
				Description = productModel.Description,
				Price = productModel.Price,
				ImageUrl = productModel.ImageUrl,
				CategoryId = productModel.CategoryId,
				Categories = productModel.Categories


			});


		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, ProductFormModel model)
		{

			if (await this.productService.ExistByIdAsynch(id) == false)
			{

				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				model.Categories = await this.categoryService.GetProductCategoryAsync();

				return this.View(model);
			}

			try
			{
				await this.productService.EditProductByIdAndFormModel(id, model);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Unexpected error occured!");

				model.Categories = await this.categoryService.GetProductCategoryAsync();




				return this.View(model);
			}

			return RedirectToAction("All", "Product");

		}



		[HttpGet]
		public async Task<IActionResult> All(int id, [FromQuery] ProductSearchQueryModel model)
		{
			var productQuery = this.dbContext.Products.AsQueryable();


			if (!string.IsNullOrWhiteSpace(model.SearchByName))
			{
				string wildCard = $"{model.SearchByName.ToLower()}%";

				productQuery = productQuery.Where(p =>
				EF.Functions.Like(p.Name, wildCard));


			}

		

			var products = await productQuery
					.OrderByDescending(c => c.Id)
					.Where(c => c.CategoryId == id)
					.Skip((model.CurrentPage - 1) * ProductSearchQueryModel.ProductsPerPage)
					.Take(ProductSearchQueryModel.ProductsPerPage)
					 .Select(p => new ProductListingVIewModel
					 {
						 Id = p.Id,
						 Name = p.Name,
						 Price = p.Price,
						 ImageUrl = p.ImageUrl,
						 Description = p.Description,
						 CategoryId = p.Id,
						 Category = p.Category.Name


					 })
					 .ToArrayAsync();

			var totalProducts = productQuery.Count();


			model.Products = products;
			model.TotalProducts = totalProducts;

			return View(model);

		}



		[HttpPost]
		public async Task<IActionResult> Add(ProductFormModel product)
		{
			if (await categoryService.ExistByIdAsync(product.CategoryId) == false)
			{
				this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist");

			}


			if (!ModelState.IsValid)
			{
				product.Categories = await this.categoryService.GetProductCategoryAsync();

				return View(product);
			}


			try
			{

				await this.productService.CreateProductAsync(product);

			}
			catch (Exception _ex)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occured");
				product.Categories = await this.categoryService.GetProductCategoryAsync();

				return View(product);
			}



			return this.RedirectToAction(nameof(All));
		}





	}


}
