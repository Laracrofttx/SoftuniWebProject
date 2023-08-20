namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.AspNetCore.Mvc;
	public class ProductController : Controller
	{
		private readonly IProductService productService;
		private readonly ICategoryService categoryService;
		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			this.productService = productService;
			this.categoryService = categoryService;
		}

		public async Task<IActionResult> Breads()
		{

			IEnumerable<BreadViewModel> breadViewModel =
				  await this.productService.AllBreads();

			return View(breadViewModel);
		}


		public async Task<IActionResult> EasterBread()
		{

			IEnumerable<EasterBreadsViewModel> easterBreadViewModel =
				  await this.productService.AllEasterBreads();

			return View(easterBreadViewModel);

		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{


			ProductViewModel viewModel = new ProductViewModel()
			{

				Categories = (IEnumerable<CategoryViewModel>)await this.productService.AllProductsAsync()
			};

		
			return View(viewModel);	
		}


		
	}
}
