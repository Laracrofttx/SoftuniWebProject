using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.Data;
using BakerySystem.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;

namespace BakerySystem.Services
{
	public class OrderService : IOrderService
	{
		private readonly BakeryDbContext dbContext;
		private readonly IProductService productService;

		public OrderService(BakeryDbContext dbContext, IProductService productService)
		{
			this.dbContext = dbContext;
			this.productService = productService;
			
		}

		public async Task<OrderViewModel> AddToOrder(int productId)
		{
			var currentProduct = await dbContext.Products.FindAsync(productId);

			return new OrderViewModel()
			{

				OrderId = currentProduct.Id,
				ProductName = currentProduct.Name,
				ProductPrice = currentProduct.Price

			};
		}
	}
}
