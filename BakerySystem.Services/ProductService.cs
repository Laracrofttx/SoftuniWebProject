namespace BakerySystem.Services
{
    using BakerySystem.Data.Models;
    using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;
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
				.OrderBy(c => c.Id)
				.Select(c => new HomeViewModel()
				{

					Id = c.Id,
					Title = c.Name,
					ImageUrl = c.ImageUrl

				})
				.ToArrayAsync();

			return allProducts;
		}

		public async Task<IEnumerable<BreadViewModel>> AllBreads()
		{

			IEnumerable<BreadViewModel> allBreads = await dbContext
				.Products
				.Select(c => new BreadViewModel
				{

					Id = c.Id,
					Name = c.Name


				})
				.ToArrayAsync();

			return allBreads;

		}



	}
}
