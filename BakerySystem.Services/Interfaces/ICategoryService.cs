using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoryAsync();

		Task<bool> ExistsByIdAsync(int id);

		Task<IEnumerable<string>> AllCategoryNamesAsync();

		Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id);
	}
}
