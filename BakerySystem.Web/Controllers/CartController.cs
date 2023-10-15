namespace BakerySystem.Web.Controllers
{
	using System;

	using BakerySystem.Data.Models;
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.ShoppingCart;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Caching.Memory;
	using static BakerySystem.Common.EntityValidationConstants;

	public class CartController : Controller
	{
		private readonly BakeryDbContext dbContext;

		private readonly IMemoryCache memoryCache;
		private readonly IProductService productService;
		

		public CartController(BakeryDbContext dbContext, IProductService productService, IMemoryCache memoryCache)
		{
			this.dbContext = dbContext;
			this.productService = productService;
			this.memoryCache = memoryCache;	
			
		}

		// Проверявам в кеша, дали има лист от продукти. Ако няма го сетвам. Ако го има, взимам продуктите. Добавям продукта в листа и добавям листа в кеша
		//
		//
		// и го връщам на вюто 

		public async Task<IActionResult> AddToCart(int id)
		{
			//if (!memoryCache.Contains("CartItem"))
			//{
			//	var cacheItemPolicy = new CacheItemPolicy();
			//	cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1);
			//	var cacheKey = baseCacheKey + userId.ToString();
			//	cache.Add(cacheKey, users, cacheItemPolicy);
			//}

			var products = memoryCache.Get("CartItem") as List<CartItem>;


			var selectedProduct = await this.dbContext
				.Products
				.Where(p => p.Id == id)
				.Select(p => new CartItem
				{

					CartItemId = id,
					ProductName = p.Name,
					Price = p.Price,
					Image = p.ImageUrl,
					TotalAmount = p.Price,
					Quantity = 1,



				})
				.FirstOrDefaultAsync();



			ViewBag.CartItem = products;

			return View();


		}



		[HttpPost]
		public async Task<IActionResult> AddToShoppingCart(Product product, int quantity)
		{

			var selectedItem = this.dbContext
				.CartItems
				.FirstOrDefault(p => p.ProductId == product.Id);

			if (selectedItem == null)
			{
				selectedItem = new CartItem
				{

					ProductId = product.Id,
					ProductName = product.Name,
					Price = product.Price,
					CartItemId = product.Id,
					Quantity = 1,
					Image = product.ImageUrl,
					TotalAmount = product.Price * quantity,



				};

				await dbContext.CartItems.AddAsync(selectedItem);
			}
			else
			{
				selectedItem.Quantity++;
			}

			await dbContext.SaveChangesAsync();

			return View(selectedItem);


		}

	}

	
}

