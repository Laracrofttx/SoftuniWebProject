namespace BakerySystem.Web.Controllers
{
	using System.Linq;
	using System.Security.Cryptography;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
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

		public List<CartItemViewModel> cartItems = null!;


		public IActionResult AddToCart()
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

			MemoryCacheEntryOptions cache = new MemoryCacheEntryOptions()
				.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

			this.memoryCache.Set(CartCacheKey, cartItems, cache);

			
			
			ViewBag.CartItems = cartItems;

			return RedirectToAction(nameof(AddToCart));



		}

		public IActionResult RemoveFromCart()
		{

			cartItems = this.memoryCache.Get<List<CartItemViewModel>>(CartCacheKey);

			var itemToRemove = cartItems.FirstOrDefault();

			if (cartItems.Count > 0)
			{

				cartItems.Remove(itemToRemove!);

			}
			if (cartItems.Count > 0)
			{
				return RedirectToAction(nameof(AddToCart));

			}

			return RedirectToAction("Index", "Home");

		}



		public IActionResult ClearAll()
		{

			this.memoryCache.Remove(CartCacheKey);

			return RedirectToAction("Index", "Home");

		}


		

	}


}

