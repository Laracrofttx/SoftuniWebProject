namespace BakerySystem.Services
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Services.Statistics;
	using BakerySystem.Web.Data;
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

		public async Task CreateProductAsync(ProductFormModel model)
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

		public async Task<bool> ExistByIdAsynch(int id)
		{
			bool result = await this.dbContext
				.Products
				.AnyAsync(p => p.Id == id);

			await dbContext.SaveChangesAsync();

			return result;

		}
	
		public async Task EditProductByIdAndFormModel(int id, ProductFormModel model)
		{
			Product product = await this.dbContext
				.Products
				.FirstAsync(p => p.Id == id);



			product.Id = model.Id;
			product.Name = model.Name;
			product.Price = model.Price;
			product.Description = model.Description;
			product.ImageUrl = model.ImageUrl;
			product.CategoryId = model.CategoryId;

				
			await dbContext.SaveChangesAsync();

		}


	
		public async Task<ProductFormModel> ProductForEditByIdAsync(int id)
		{
			Product product = await this.dbContext
				.Products
				.Include(p => p.Category)
				.FirstAsync(p => p.Id == id);


			return new ProductFormModel
			{
				Id = id,
				Name = product.Name,
				Price = product.Price,
				Description = product.Description,
				ImageUrl = product.ImageUrl,
				CategoryId = product.CategoryId,
				
			};


		}

		public async Task<ProductForDeleteViewModel> ProductForDeleteByIdAsynch(int productId)
		{
			var product = await this.dbContext
				.Products
				.FindAsync(productId);

			return new ProductForDeleteViewModel()
			{

				Name = product.Name,
				Price = product.Price,
				ImageUrl = product.ImageUrl


			};

		}

		public async Task DeleteProductByIdAsynch(int productId)
		{
			Product productToDelete = await this.dbContext
				.Products
				.FirstAsync(p => p.Id == productId);

			productToDelete.isAvailable = false;

			dbContext.Remove(productToDelete);

			await dbContext.SaveChangesAsync();

			
		}

        public async Task<ProductDetailsServiceModel> ProductDetailsByIdAsynch(int id)
        {
			Product product = await this.dbContext
				 .Products
				 .Include(c => c.Category)
				 .Where(p => p.Id == id)
				 .FirstAsync();

			return new ProductDetailsServiceModel()
			{

				Id = product.Id,
				Name = product.Name,
				Price = product.Price,
				ImageUrl = product.ImageUrl,
				Description = product.Description,
				Category = product.Category.Name


			};
				
			
				
        }

		public async Task<Product> GetProductByIdAsynch(int id)
		{
			var currentProduct = await this.dbContext
				.Products
				.Where(p => p.Id == id)
				.FirstOrDefaultAsync();

			return currentProduct;
		}

		public async Task<StatisticServiceModel> GetStatisticsAsynch()
		{
			return new StatisticServiceModel()
			{

				TotalProducts = await this.dbContext.Products.CountAsync(),
				TotalCategories = await this.dbContext.Categories.CountAsync(),

			};
		}

	}
}
