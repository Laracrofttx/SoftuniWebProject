namespace BakerySystem.Web.Areas.Admin.Controllers
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Areas.Admin.ViewModels;
	using BakerySystem.Web.Areas.Admin.ViewModels.Product;
	using BakerySystem.Web.Infrastructure.Extensions;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.AspNetCore.Mvc;

	using static BakerySystem.Common.GeneralApplicationConstants;
	public class ProductController : BaseAdminController
	{
		private readonly IProductService productService;
		private readonly IUserService userService;

		public ProductController(IProductService productService, IUserService userService)
		{
			this.productService = productService;
			this.userService = userService;
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
