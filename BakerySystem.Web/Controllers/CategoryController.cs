using BakerySystem.Services.Interfaces;
using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BakerySystem.Web.Controllers
{
	[Authorize]
	public class CategoryController : Controller
	{
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> All()
		{
			IEnumerable<CategoryViewModel> viewModel =
				await categoryService.AllCategoriesAsync();

			return View(viewModel);
		}

		
		//public async Task<IActionResult> Category(int id)
		//{
		//	//CategoryModel viewModel =
		//	//	await categoryService.GetCategoryInfoById(id);

		//	return View(viewModel);
		//}




	}


	
}
