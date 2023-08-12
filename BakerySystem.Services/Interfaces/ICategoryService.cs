using BakerySystem.Web.ViewModels.Category;

namespace BakerySystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoryAsync();

		Task<IEnumerable<BreadViewModel>> AllBreads();

	}
}
