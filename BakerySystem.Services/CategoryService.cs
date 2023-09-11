namespace BakerySystem.Services
{
	using Microsoft.EntityFrameworkCore;
	
	using BakerySystem.Web.Data;
	using System.Collections.Generic;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Data.Models;
	using System.Threading.Tasks;

	public class CategoryService : ICategoryService
	{
		private readonly BakeryDbContext dbContext;

		public CategoryService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> CategoryExists(int categoryId)
		{
			return await dbContext.Categories.AnyAsync(c => c.Id == categoryId);
		}

		public async Task<int> Create(string categoryName, int categoryId)
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




		public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
		{
			IEnumerable<CategoryViewModel> allCategories = await dbContext
				.Categories
				.AsNoTracking()
				 .Select(c => new CategoryViewModel
				 {

					 Id = c.Id,
					 Name = c.Name

				 })
				.ToArrayAsync();

			return allCategories;
		}


	}

}


