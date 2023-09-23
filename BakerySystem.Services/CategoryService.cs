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

		public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
		{
			IEnumerable<CategoryViewModel> categories = await this.dbContext
				.Categories
				.Select(c => new CategoryViewModel
				{

					Id = c.Id,
					Name = c.Name

				})
				.ToArrayAsync();

			return categories;
		}

		//public async Task<int> Create(string categoryName, int categoryId)
		//{
		//	var category = new Category()
		//	{

		//		Id = categoryId,
		//		Name = categoryName


		//	};

		//	 await dbContext.Categories.AddAsync(category);
		//	 await dbContext.SaveChangesAsync();


		//	return category.Id;
		//}






	}

}


