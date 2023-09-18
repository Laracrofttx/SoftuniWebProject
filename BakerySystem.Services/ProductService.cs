namespace BakerySystem.Services
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Home;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;
	using System.Threading.Tasks;

	public class ProductService : IProductService
	{
		private readonly BakeryDbContext dbContext;

		public ProductService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;

		}

		public async Task CreateProductAsync(ProductViewModel model)
		{
			var product = new Product
			{
				Id = model.Id,
				Name = model.Name,
				Price = model.Price,
				ImageUrl = model.ImageUrl,
				Description = model.Description,
				CategoryId = model.CategoryId

				
			};

			await this.dbContext.Products.AddAsync(product);
			await this.dbContext.SaveChangesAsync();
		}








		//public IEnumerable<ProductSearchQueryModel> Search(string searchTerm)
		//{
		//	var productQuery = this.dbContext.Products.AsQueryable();

		//	if (!string.IsNullOrWhiteSpace(searchTerm))
		//	{


		//	}


		//	return (productQuery = productQuery.Where
		//			(p => p.Name.ToLower().Contains(searchTerm.ToLower()));

		//}
	}
}
