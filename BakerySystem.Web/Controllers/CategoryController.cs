using BakerySystem.Services.Interfaces;
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

		//public async Task<IActionResult> Index()
		//{
		//	IEnumerable<CategoryViewModel> categoryViewModels =
		//		await this.categoryService.AllCategoryAsync();

		//	return View(categoryViewModels);
		//}

		//public async Task<IActionResult> All()
		//{
		//	IEnumerable<CategoryViewModel> categoryViewModels =
		//		await this.categoryService.AllCategoryAsync();

		//	//var categories = await categoryService
		//	//	.AllCategoryAsync();


		//	return View(categoryViewModels);
		//}

		//[HttpGet]
		//public async Task<IActionResult> Breads()
		//{

		//	IEnumerable<BreadViewModel> breadViewModel =
		//		  await this.categoryService.AllBreads();


		//	return View(breadViewModel);

		//}

		//[HttpGet]
		//public async Task<IActionResult> EasterBreads()
		//{

		//	IEnumerable<EasterBreadsViewModel> easterBreadViewModel =
		//		  await this.categoryService.AllEasterBreads();

		//	return RedirectToAction(actionName: "All", controllerName: "Product");
		//}

	
	}
}
