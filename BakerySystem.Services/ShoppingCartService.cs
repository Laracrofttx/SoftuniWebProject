namespace BakerySystem.Services
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.ShoppingCart;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;
	using System.Threading.Tasks;

	public class ShoppingCartService : IShoppingCartService
	{
		private readonly BakeryDbContext dbContext;

        public ShoppingCartService(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Remove(CartItemViewModel item)
		{
			var productToRemove = await this.dbContext
				.Products
				.FirstAsync(p => p.Id == item.Id);

		
			
		}
	}
}
