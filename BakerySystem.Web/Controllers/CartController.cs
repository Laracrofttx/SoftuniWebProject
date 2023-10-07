namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.ShoppingCart;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.EntityFrameworkCore;

	public class CartController : Controller
	{
		private readonly BakeryDbContext dbContext;

		private readonly IProductService productService;

		public int ShoppingCartId { get; set; }

		public CartController(BakeryDbContext dbContext, IProductService productService)
		{
			this.dbContext = dbContext;
			this.productService = productService;
		}

		public async Task<IActionResult> GetCartId(int id)
		{

			var productById = await this.dbContext
				.Carts
				.Where(p => p.CartId == id)
				.FirstOrDefaultAsync();

			return View(productById);


		}


		public async Task<IActionResult> AddToCart(int id)
		{


			var selectedProduct = await this.dbContext
				.Products
				.Where(p => p.Id == id)
				.Select(p => new CartItemViewModel
				{

					Id = id,
					Title = p.Name,
					Price = p.Price,
					Image = p.ImageUrl,
					TotalPrice = p.Price,
					Quantity = 1,



				})
				.FirstOrDefaultAsync();


			return View(selectedProduct);

			//var selectedProduct = await dbContext.Products
			//	.FirstOrDefaultAsync(p => p.Id == id);

			//if (selectedProduct != null)
			//{

			//	await AddToShoppingCart(selectedProduct, 1);

			//}
			//return View(selectedProduct);
		}

		[HttpPost]
		public async Task<IActionResult> AddToShoppingCart(Product product, int amount)
		{

			var selectedItem = this.dbContext
				.CartItems
				.FirstOrDefault(p => p.ProductId == product.Id && p.CartId == ShoppingCartId);

			if (selectedItem == null)
			{
				selectedItem = new CartItem
				{

					CartId = ShoppingCartId,
					ProductId = product.Id,
					ProductName = product.Name,
					Price = product.Price,
					CartItemId = product.Id,
					Quantity = 1,
					Products = product,
					Image = product.ImageUrl,
					TotalAmount = amount



				};

				dbContext.CartItems.AddAsync(selectedItem);
			}
			else
			{
				selectedItem.Quantity++;
			}

			dbContext.SaveChangesAsync();

			return View(selectedItem);
		}

	}
}
