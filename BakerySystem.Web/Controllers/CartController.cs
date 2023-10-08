namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.ShoppingCart;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.EntityFrameworkCore;
	using System;

	public class CartController : Controller
	{
		private readonly BakeryDbContext dbContext;

		private readonly IProductService productService;
		

		public CartController(BakeryDbContext dbContext, IProductService productService)
		{
			this.dbContext = dbContext;
			this.productService = productService;
			

		}

		
		public async Task<IActionResult> AddToCart(int id)
		{

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

			return View(selectedProduct);


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

