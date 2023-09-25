namespace BakerySystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Product;
    using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Home;
    public class HomeController : Controller
    {
        private readonly BakeryDbContext dbContext;

        private readonly IProductService productService;
        public HomeController(BakeryDbContext dbContext,IProductService productService)
        {
            this.dbContext = dbContext;
            this.productService = productService;    
        }

       
        public async Task<IActionResult> Index()
        {
            
            var categories = await this.dbContext.Categories.ToListAsync();

            //IEnumerable <ProductIndexViewModel> productViewModel =
            //    await this.productService.AllProductsAsync();

            var products = await this.dbContext
                .Products
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,

                })
                .ToListAsync();

            return View(products);



        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}