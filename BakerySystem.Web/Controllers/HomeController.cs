namespace BakerySystem.Web.Controllers
{
	using System.Threading.Tasks;
	using BakerySystem.Web.Data;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Home;

    using static Common.GeneralApplicationConstants;

	public class HomeController : Controller
    {
        private readonly BakeryDbContext dbContext;

        public HomeController(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;
           
        }

       
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

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
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            if (statusCode == 401)
            {
                return this.View("Error401");
            }
            return View();
        }
    }
}