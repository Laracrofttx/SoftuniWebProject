namespace BakerySystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Areas.Admin.ViewModels.Product;
	public class ProductController : BaseAdminController
	{
		private readonly IProductService productService;

		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}
		public async Task<IActionResult> All()
		{


			ProductListingViewModel models = new ProductListingViewModel()
			{

				AllProducts = await this.productService.GetAllProductsAsync()

			};


			return View(models);
		}
	}
}
