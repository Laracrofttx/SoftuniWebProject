namespace BakerySystem.Services
{
    using BakerySystem.Data.Models;
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

		public async Task<IEnumerable<HomeViewModel>> AllProductsAsync()
		{
			IEnumerable<HomeViewModel> allProducts = await this.dbContext
				.Products
				.Select(c => new HomeViewModel()
				{

					Id = c.Id,
					Title = c.Name,
					ImageUrl = c.ImageUrl
					
				})
				.ToArrayAsync();
			dbContext.SaveChanges();

			return allProducts;
		}
		

      
    }
}
