using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoryAsync();

		//Task<IEnumerable<BreadViewModel>> AllBreads();

        //Task<IEnumerable<EasterBreadsViewModel>> AllEasterBreads();

	}
}
