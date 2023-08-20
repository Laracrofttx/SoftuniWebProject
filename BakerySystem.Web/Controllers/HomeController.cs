namespace BakerySystem.Web.Controllers
{
    using BakerySystem.Services.Interfaces;
    using BakerySystem.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using ViewModels.Home;
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        public HomeController(IProductService productService)
        {
            this.productService= productService;    
        }

       
        public async Task<IActionResult> IndexAsync()
        { 
            IEnumerable<HomeViewModel> productViewModel = 
                await this.productService.AllProductsAsync();

            return View(productViewModel);  
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}