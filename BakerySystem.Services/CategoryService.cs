namespace BakerySystem.Services
{
	using Microsoft.EntityFrameworkCore;

	using BakerySystem.Web.Data;
	using System.Collections.Generic;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Data.Models;
	using System.Threading.Tasks;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.EntityFrameworkCore.Metadata.Internal;

	public class CategoryService : ICategoryService
	{
		private readonly BakeryDbContext dbContext;

		public CategoryService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<ProductCategoryViewModel>> GetProductCategoryAsync()
		{
			IEnumerable<ProductCategoryViewModel> allCategories = await dbContext
				.Categories
				.AsNoTracking()
				 .Select(c => new ProductCategoryViewModel
				 {

					 Id = c.Id,
					 Name = c.Name

				 })
				.ToArrayAsync();

			return allCategories;
		}



		public async Task<bool> ExistByIdAsync(int categoryId)
		{
			bool result = await this.dbContext
				.Categories
				.AnyAsync(c => c.Id == categoryId);

			return result;
		}

		public async Task<IEnumerable<CategoryListingViewModel>> AllCategoriesAsync()
		{
			IEnumerable<CategoryListingViewModel> categories = await this.dbContext
				.Categories
				.AsNoTracking()
				.Select(c => new CategoryListingViewModel
				{

					Id = c.Id,
					Name = c.Name

				})
				.ToArrayAsync();

			return categories;
		}



		public async Task<int> CreateAsynch(int categoryId, string categoryName)
		{
			var category = new Category()
			{

				Id = categoryId,
				Name = categoryName


			};

			await dbContext.Categories.AddAsync(category);
			await dbContext.SaveChangesAsync();


			return category.Id;
		}

		public async Task<CategoryViewModel> EditByIdAsync(int id)
		{

			var categoryForEdit = await this.dbContext
				.Categories
				.FirstAsync(c => c.Id == id);


			return new CategoryViewModel
			{

				Id = categoryForEdit.Id,
				Name = categoryForEdit.Name,


			};

		}

		public async Task EditByIdAndFormModelAsync(int id, CategoryViewModel model)
		{
			Category category = await this.dbContext
				.Categories
				.FirstAsync(c => c.Id == id);

			category.Id = id;
			category.Name = model.Name;


			await dbContext.SaveChangesAsync();

		}
	}
}


