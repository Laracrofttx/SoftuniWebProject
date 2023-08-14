using BakerySystem.Services.Interfaces;
using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
    public class CategoryController : Controller
	{
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			IEnumerable<CategoryViewModel> viewModel =
				await categoryService.AllCategoryAsync();

			return View(viewModel);
		}

		

	}
}
