namespace BakerySystem.Services
{
    using BakerySystem.Data.Models;
    using BakerySystem.Services.Interfaces;
    using BakerySystem.Web.Data;
    using BakerySystem.Web.ViewModels.Home;
    using BakerySystem.Web.ViewModels.Product;
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
			

			return allProducts;
		}

		public async Task<IEnumerable<BreadViewModel>> AllBreads()
		{

			IEnumerable<BreadViewModel> allBreads = await dbContext
				.Products
				.Select(c => new BreadViewModel
				{

					Id = c.Id,
					Name = c.Name,
					Price = c.Price,
					Description = c.Description


				})
				.ToArrayAsync();
			
			return allBreads;

		}

		public async Task<IEnumerable<EasterBreadsViewModel>> AllEasterBreads()
		{

			IEnumerable<EasterBreadsViewModel> allEasterBreads = await dbContext
				.Products
				.Select(c => new EasterBreadsViewModel()
				{

					Id = c.Id,
					Name = c.Name,
					Price = c.Price,
					Description = c.Description


				})
				.ToArrayAsync();

			

			return allEasterBreads;


		}
	}
}
