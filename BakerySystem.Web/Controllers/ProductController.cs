namespace BakerySystem.Web.Controllers
{
	using System.Collections.Generic;
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using Microsoft.EntityFrameworkCore;

	public class ProductController : Controller
	{
		private readonly BakeryDbContext data;


		private readonly IProductService productService;
		private readonly ICategoryService categoryService;
		public ProductController(BakeryDbContext data, IProductService productService, ICategoryService categoryService)
		{
			this.data = data;
			this.productService = productService;
			this.categoryService = categoryService;
		}

		public async Task<IActionResult> Add() => View(new ProductListViewModel
		{


			Categories = await this.GetProductCategory()


		});

		[HttpPost]
		public async Task<IActionResult> Add(ProductListViewModel product)
		{
			if (!this.data.Categories.Any(c => c.Id == product.CategoryId))
			{
				this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist");

			}


			if (!ModelState.IsValid)
			{
				product.Categories = await this.GetProductCategory();

				return View(product);
			}

			var  productData =  new Product
			{

				Name = product.Name,
				Price = product.Price,
				ImageUrl = product.ImageUrl,
				Description = product.Description,
				CategoryId = product.CategoryId,


			};

			this.data.Products.Add(productData);
			this.data.SaveChanges();


			return RedirectToAction("Index", "Home");
		}

		private async Task<IEnumerable<ProductCategoryViewModel>> GetProductCategory()
			=> await this.data
			.Categories
			.Select(c => new ProductCategoryViewModel
			{
				Id = c.Id,
				Name = c.Name,

			})
			.ToListAsync();



		public async Task<IActionResult> Breads()
		{

			IEnumerable<ProductListViewModel> breadViewModel =
				  await this.productService.AllBreads();

			return View(breadViewModel);
		}


		public async Task<IActionResult> EasterBread()
		{

			IEnumerable<ProductListViewModel> easterBreadViewModel =
				  await this.productService.AllEasterBreads();

			return View(easterBreadViewModel);

		}



		//[HttpGet]
		//public async Task<IActionResult> Add()
		//{


		//	ProductViewModel viewModel = new ProductViewModel()
		//	{

		//		Categories = (IEnumerable<CategoryViewModel>)await this.productService.AllProductsAsync()
		//	};


		//	return View(viewModel);	
		//}



	}
}
