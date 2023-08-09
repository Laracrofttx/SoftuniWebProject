namespace BakerySystem.Web.Controllers
{
    using BakerySystem.Data.Models;
    using BakerySystem.Services.Interfaces;
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

       
    }
}
