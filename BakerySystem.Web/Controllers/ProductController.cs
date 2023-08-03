namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	public class ProductController : Controller
	{
		public async Task<IActionResult> All()
		{
			return View();
		}
	}
}
