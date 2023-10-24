namespace BakerySystem.Web.Controllers
{
	using System.Linq;
	using AutoMapper.Internal;
	using BakerySystem.Data.Models;
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Product;
	using BakerySystem.Web.ViewModels.ShoppingCart;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Caching.Memory;

	using static Common.GeneralApplicationConstants;

	[Authorize]
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
		
		public List<CartItemViewModel> cartItems;


		public async Task<IActionResult> AddToCart()
		{

			cartItems = this.memoryCache.Get<List<CartItemViewModel>>(CartCacheKey);

			if (cartItems == null)
			{
				cartItems = new List<CartItemViewModel>();
			}

			ViewBag.CartItems = cartItems;

			return View();

		}




		[HttpPost]
		public async Task<IActionResult> AddToCart(int id)
		{

			cartItems = this.memoryCache.Get<List<CartItemViewModel>>(CartCacheKey);

			if (cartItems == null)
			{
				cartItems = new List<CartItemViewModel>();
			}
			
			var product = await this.dbContext
				.Products
				.Where(p => p.Id == id)
				.Select(p => new CartItemViewModel
				{
					Id = p.Id,
					Title = p.Name,
					Price = p.Price,
					Image = p.ImageUrl,
					Quantity = 1,
					TotalPrice = p.Price


				})
				.FirstOrDefaultAsync();


			if (product != null)
			{
				cartItems.Add(product);
			}
			else if(cartItems.Contains(product!))
			{
				product!.Quantity += 1;
			}
			


			MemoryCacheEntryOptions cache = new MemoryCacheEntryOptions()
				.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
			/*IEnumerable<ProductListingVIewModel>*/
			this.memoryCache.Set(CartCacheKey, cartItems, cache);
			//this.memoryCache.Set(CartCacheKey, selectedProduct, cache);


			ViewBag.CartItems = cartItems;

			return RedirectToAction(nameof(AddToCart));



		}



		//[HttpPost]
		//public async Task<IActionResult> AddToShoppingCart(Product product, int quantity)
		//{

		//	var selectedItem = this.dbContext
		//		.CartItems
		//		.FirstOrDefault(p => p.ProductId == product.Id);

		//	if (selectedItem == null)
		//	{
		//		selectedItem = new CartItem
		//		{

		//			ProductId = product.Id,
		//			ProductName = product.Name,
		//			Price = product.Price,
		//			CartItemId = product.Id,
		//			Quantity = 1,
		//			Image = product.ImageUrl,
		//			TotalAmount = product.Price * quantity,



		//		};

		//		await dbContext.CartItems.AddAsync(selectedItem);
		//	}
		//	else
		//	{
		//		selectedItem.Quantity++;
		//	}

		//	await dbContext.SaveChangesAsync();

		//	return View(selectedItem);


		//}

	}


}

