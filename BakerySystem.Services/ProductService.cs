namespace BakerySystem.Services
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Home;
	using Microsoft.EntityFrameworkCore;

	public class ProductService : IProductService
	{
		private readonly BakeryDbContext dbContext;

		public ProductService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<HomeProductsViewModel>> AllProductsAsync()
		{
			IEnumerable<HomeProductsViewModel> allProducts = await this.dbContext
				.Products
				.OrderByDescending(c => c.Id)
				.Select(c => new HomeProductsViewModel()
				{

					Id = c.Id,
					Title = c.Name,
					ImageUrl = c.ImageUrl

				})
				.ToArrayAsync();
				
			return allProducts;
		}

        
    }
}
