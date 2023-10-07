using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.Data;
using BakerySystem.Web.ViewModels.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BakerySystem.Services
{
	public class OrderService : IOrderService
	{
		private readonly BakeryDbContext dbContext;
		private readonly IProductService productService;

		public int ShoppingCartItemId { get; set; }
		public OrderService(BakeryDbContext dbContext, IProductService productService)
		{
			this.dbContext = dbContext;
			this.productService = productService;

		}

		public async Task AddToOrder(int id)
		{
			
		}
	}
}
