using BakerySystem.Data.Models;
using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Services.Interfaces
{
    public interface ICategoryService
    {
		Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();

		Task<bool> CategoryExists(int categoryId);

		Task<int> Create(string categoryName, int categoryId);
	}
}
