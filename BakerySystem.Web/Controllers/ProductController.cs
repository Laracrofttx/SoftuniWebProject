namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Category;
	using Microsoft.AspNetCore.Mvc;
	public class ProductController : Controller
    {
		private readonly IProductService productService;

		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}

		public async Task<IActionResult> All()
		{
			 return View();
		}

		public async Task<IActionResult> Add()
		{

			return View();
		}
       
    }
}
