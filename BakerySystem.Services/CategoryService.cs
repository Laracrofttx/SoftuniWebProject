namespace BakerySystem.Services
{
	using Microsoft.EntityFrameworkCore;
	
	using BakerySystem.Web.Data;
	using System.Collections.Generic;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Category;

	public class CategoryService : ICategoryService
	{
		private readonly BakeryDbContext dbContext;

		public CategoryService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
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


