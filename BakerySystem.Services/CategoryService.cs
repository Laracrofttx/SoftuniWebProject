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
	using BakerySystem.Services.Mapping;

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
				.To<CategoryListingViewModel>()
				.ToArrayAsync();

			return categories;
		}


		public async Task<CategoryDetailsViewModel> CategoryDetailsByIdAsync(int id)
		{
			Category category = await this.dbContext
				.Categories
				.Where(c => c.Id == id)
				.FirstAsync();

			return new CategoryDetailsViewModel()
			{

				Id = category.Id,
				Name = category.Name

			};

		}

		public async Task<CategoryViewModel> EditByIdAsync(int id)
		{

			var categoryForEdit = await this.dbContext
				.Categories
				.FirstAsync(c => c.Id == id);


			return new CategoryViewModel()
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

		public async Task<CategoryDeleteViewModel> DeleteByIdAsync(int id)
		{
			var categoryForDelete = await this.dbContext
				.Categories
				.FirstAsync(c => c.Id == id);


			return new CategoryDeleteViewModel()
			{

				Id = id,
				Name = categoryForDelete.Name,


			};




		}

		public async Task DeleteAsync(int id)
		{
			Category categoryToDelete = await this.dbContext
				.Categories
				.FirstAsync(c => c.Id == id);

			//categoryToDelete.IsAvailable = false;
			
			dbContext.Remove(categoryToDelete);
			await dbContext.SaveChangesAsync();
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



		public async Task<int> CreateAsynch(CategoryViewModel model)
		{
			var category = new Category()
			{

				Id = model.Id,
				Name = model.Name,

			};

			await dbContext.Categories.AddAsync(category);
			await dbContext.SaveChangesAsync();

			return category.Id;
		}
	}
}


