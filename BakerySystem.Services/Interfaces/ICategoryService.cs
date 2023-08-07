using BakerySystem.Data.Models;
using BakerySystem.Web.ViewModels.Home;

namespace BakerySystem.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoryAsync();
    }
}
