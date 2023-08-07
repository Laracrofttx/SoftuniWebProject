using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.ViewModels.Home;
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

		public async Task<IActionResult> Index()
		{
            IEnumerable<CategoryViewModel> homeViewModels =
                await this.categoryService.AllCategoryAsync();

            return View(categoryService);
		}
	}
}
