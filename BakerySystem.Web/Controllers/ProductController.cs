﻿namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Product;
	using Microsoft.AspNetCore.Mvc;
	public class ProductController : Controller
	{
		private readonly IProductService productService;

		public ProductController(IProductService productService)
		{
			this.productService = productService;
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


	}
}
