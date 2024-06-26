﻿using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Services.Interfaces
{
	public interface ICategoryService
    {
		Task<int> CreateAsynch(CategoryViewModel model);
		Task<IEnumerable<CategoryListingViewModel>> AllCategoriesAsync();
		Task<IEnumerable<ProductCategoryViewModel>> GetProductCategoryAsync();
		Task<bool> ExistByIdAsync(int categoryId);
		Task<CategoryDetailsViewModel> CategoryDetailsByIdAsync(int id);
		Task<CategoryViewModel> EditByIdAsync(int id);
		Task EditByIdAndFormModelAsync(int id, CategoryViewModel model);
		Task<CategoryDeleteViewModel> DeleteByIdAsync(int id);
		Task DeleteAsync(int id);
	}
}
