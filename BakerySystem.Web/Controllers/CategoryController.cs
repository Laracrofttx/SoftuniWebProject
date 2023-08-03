using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
