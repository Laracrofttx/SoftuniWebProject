namespace BakerySystem.Services
{
    using BakerySystem.Data.Models;
    using BakerySystem.Services.Interfaces;
    using BakerySystem.Web.Data;
    using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    public class CategoryService : ICategoryService
    {
        private readonly BakeryDbContext dbContext;

        public CategoryService(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<IEnumerable<CategoryViewModel>> AllCategoryAsync()
        {
            IEnumerable<CategoryViewModel> allCategories = await dbContext
                .Categories
                 .Select(c => new CategoryViewModel
                {
                
                    Id= c.Id,
                    Name = c.Name
                
                })
                .ToArrayAsync();

            return allCategories;

        }
	

		public async Task<bool> ExistsByIdAsync(int id)
		{
			bool result = await dbContext
				.Categories
				.AnyAsync(c => c.Id == id);

			return result;
		}

		public async Task<IEnumerable<string>> AllCategoryNamesAsync()
		{
			IEnumerable<string> allNames = await dbContext
				.Categories
				.Select(c => c.Name)
				.ToArrayAsync();

			return allNames;
		}

		public async Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id)
		{
			Category category = await dbContext
				.Categories
				.FirstAsync(c => c.Id == id);

			CategoryDetailsViewModel viewModel = new CategoryDetailsViewModel()
			{
				Id = category.Id,
				Name = category.Name
			};
			return viewModel;
		}
	}

}


