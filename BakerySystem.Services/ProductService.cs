namespace BakerySystem.Services
{
	using System.Threading.Tasks;
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

		public async Task Edit(int id, string name, string description, decimal price, string imageUrl, int categoryId)
		{

			var product = await this.dbContext
				.Products
				.FindAsync(id);

			product.Name = name;
			product.Description = description;
			product.Price = price;
			product.ImageUrl = imageUrl;
			product.CategoryId = categoryId;

			await this.dbContext.SaveChangesAsync();

			
		}




		public async Task<ProductFormModel> EditProductByIdAndFormModel(int id, ProductFormModel model)
		{
			var product = await this.dbContext
				.Products
				.FirstAsync(x => x.Id == id);



			await this.dbContext.SaveChangesAsync();

			return new ProductFormModel
			{

				Id = id,
		      Name = model.Name,
			  Price = model.Price,
			  Description = model.Description,
			  ImageUrl = model.ImageUrl,
			  CategoryId = model.CategoryId

			  
		    };

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
		var product = await this.dbContext
			.Products
			.FirstOrDefaultAsync(p => p.Id == id);

		await this.dbContext.SaveChangesAsync();

		return new ProductFormModel
		{



		};


	}





}
}
