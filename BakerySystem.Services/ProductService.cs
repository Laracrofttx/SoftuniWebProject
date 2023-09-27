namespace BakerySystem.Services
{
	using System.Threading.Tasks;
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Category;
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

				
			await this.dbContext.SaveChangesAsync();

		}

		public async Task<bool> ExistByIdAsynch(int id)
		{
			bool result = await this.dbContext
				.Products
				.AnyAsync(p => p.Id == id);

			await this.dbContext.SaveChangesAsync();

			return result;

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





	}
}
