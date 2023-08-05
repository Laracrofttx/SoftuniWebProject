﻿namespace BakerySystem.Web.Controllers
{
    using BakerySystem.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using ViewModels.Home;
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<HomeProductsViewModel> viewModel = await this.productService.AllProductsAsync();


            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}