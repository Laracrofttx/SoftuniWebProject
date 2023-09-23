using BakerySystem.Data.Models;
using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Services.Interfaces
{
    public interface ICategoryService
    {
		//Task<CategoryViewModel> AllCategoriesAsync();
		Task<IEnumerable<ProductCategoryViewModel>> GetProductCategoryAsync();

		Task<bool> ExistByIdAsync(int categoryId);

		//Task<int> Create(string categoryName, int categoryId);
	}
}
