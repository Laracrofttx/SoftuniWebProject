namespace BakerySystem.Services
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Home;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;

	public class ProductService : IProductService
	{
		private readonly BakeryDbContext dbContext;

		public ProductService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;

		}

		//public async Task<IEnumerable<HomeViewModel>> AllProductsAsync()
		//{
		//	IEnumerable<HomeViewModel> allProducts = await this.dbContext
		//		.Products
		//		.AsNoTracking()
		//		.Select(c => new HomeViewModel()
		//		{

		//			Id = c.Id,
		//			Name = c.Name,
		//			ImageUrl = c.ImageUrl


		//		})
		//		.ToArrayAsync();


		//	return allProducts;
		//}

		//public async Task<IEnumerable<ProductListingVIewModel>> AllProducts()
		//{

		//	var products = await this.dbContext
		//               .Products
		//               .OrderByDescending(p => p.Id)
		//                .Select(p => new ProductListingVIewModel
		//			 {

		//				 Id = p.Id,
		//				 Name = p.Name,
		//				 Price = p.Price,
		//				 ImageUrl = p.ImageUrl,
		//				 Description = p.Description


		//			 })
		//                .ToArrayAsync();


		//	return products;

		//}

		public async Task<IEnumerable<ProductListingVIewModel>> All()
		{

			IEnumerable<ProductListingVIewModel> allBreads = await dbContext
				.Products
				.Select(c => new ProductListingVIewModel()
				{

					Id = c.Id,
					Name = c.Name,
					Price = c.Price,
					Description = c.Description,
					CategoryId = c.CategoryId


				})
				.ToArrayAsync();



			return allBreads;
		}

		public async Task<IEnumerable<ProductListingVIewModel>> AllEasterBreads()
		{

			IEnumerable<ProductListingVIewModel> allEasterBreads = await dbContext
				.Products
				.Select(c => new ProductListingVIewModel()
				{

					Id = c.Id,
					Name = c.Name,
					Price = c.Price,
					Description = c.Description


				})
				.ToArrayAsync();



			return allEasterBreads;
		}



		public Product GetProductById(int Id) => this.dbContext.Products.FirstOrDefault(p => p.Id == Id);

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
