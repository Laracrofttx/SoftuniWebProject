namespace BakerySystem.Web.Controllers
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.Infrastructure.Extensions;
	using BakerySystem.Web.ViewModels.Product;

	using static Common.NotificationMessagesConstants;

	[Authorize]
	public class ProductController : Controller
	{
		public readonly BakeryDbContext dbContext;

		private readonly IProductService productService;
		private readonly ICategoryService categoryService;


		public ProductController(BakeryDbContext dbContext, IProductService productService, ICategoryService categoryService)
		{
			this.dbContext = dbContext;
			this.productService = productService;
			this.categoryService = categoryService;

		}


		public async Task<IActionResult> Add()
		{

			if (!User.isAdmin())
			{

				return RedirectToAction("Index", "Home");
			}

			return View(new ProductFormModel
			{

				Categories = await this.categoryService.GetProductCategoryAsync()


			});

		}


		//public async Task<IActionResult> Add() => View(new ProductFormModel
		//{
		//	Categories = await this.categoryService.GetProductCategoryAsync()

		//});


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{


			if (await this.productService.ExistByIdAsynch(id) == false)
			{
				return RedirectToAction("All", "Product");

			}

			if (!User.isAdmin())
			{

				return RedirectToAction("Index", "Home");
			}

			try
			{
				ProductFormModel productModel = await this.productService
				.ProductForEditByIdAsync(id);

				productModel.Categories = await this.categoryService.GetProductCategoryAsync();

				return View(productModel);
			}
			catch (Exception)
			{

				return BadRequest();

			}


		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, ProductFormModel model)
		{

			if (await this.productService.ExistByIdAsynch(id) == false)
			{

				return BadRequest();
			}

			if (!User.isAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			if (!ModelState.IsValid)
			{
				model.Categories = await this.categoryService.GetProductCategoryAsync();

				return this.View(model);
			}


			if (await this.categoryService.ExistByIdAsync(model.CategoryId) == false)
			{

				this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist!");
			}

			try
			{
				await this.productService.EditProductByIdAndFormModel(id, model);


				TempData[SuccessMessage] = "Product was edited successfully!";

			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Unexpected error occured!");

				model.Categories = await this.categoryService.GetProductCategoryAsync();

				return this.View(model);
			}


			return RedirectToAction(nameof(All), new { id });
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Details(int id)
		{
			bool pr = await productService.ExistByIdAsynch(id);

			if (!pr)
			{
				return RedirectToAction("All", "Product");
			}


			try
			{
				ProductDetailsServiceModel model = await productService.ProductDetailsByIdAsynch(id);

				return View(model);
			}
			catch (Exception)
			{

				return BadRequest();
			}
		}



		[HttpGet]
		[AllowAnonymous]
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

			if (!User.isAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			if (!ModelState.IsValid)
			{
				product.Categories = await this.categoryService.GetProductCategoryAsync();

				return View(product);
			}


			try
			{

				await this.productService.CreateProductAsync(product);

				TempData[SuccessMessage] = "Product was added successfully!";
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occured");
				product.Categories = await this.categoryService.GetProductCategoryAsync();

				return View(product);
			}



			return this.RedirectToAction(nameof(All));
		}


		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			bool productExist = await this.productService
				.ExistByIdAsynch(id);


			if (!productExist)
			{
				TempData[ErrorMessage] = "Selected product does not exist!";

				return RedirectToAction("All", "Product");

			}

			if (!User.isAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			try
			{
				ProductForDeleteViewModel productModel = await this.productService
					.ProductForDeleteByIdAsynch(id);

				return View(productModel);

			}
			catch (Exception)
			{

				return BadRequest();
			}

		}


		[HttpPost]
		public async Task<IActionResult> Delete(int id, ProductForDeleteViewModel productId)
		{

			bool productExists = await this.productService
				.ExistByIdAsynch(id);

			if (!productExists)
			{

				return RedirectToAction("All", "Product");

			}

			if (!User.isAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			try
			{
				await this.productService.DeleteProductByIdAsynch(id);


				return RedirectToAction("Index", "Home");
			}
			catch (Exception)
			{

				return BadRequest();
			}

		}

	}


}
