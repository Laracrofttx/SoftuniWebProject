namespace BakerySystem.Services
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Home;

	public class ProductService : IProductService
	{
		private readonly BakeryDbContext dbContext;

		public ProductService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<IndexViewModel>> AllProductsAsync()
		{
			return dbContext
				.Categories
				.OrderByDescending(c => c.Id)
				.Select(c => new IndexViewModel()
				{

					id = c.Id,
					Title = c.Name,
					ImageUrl = c.ImageUrl


				})
				.Take(3);
			
		}
	}
}
