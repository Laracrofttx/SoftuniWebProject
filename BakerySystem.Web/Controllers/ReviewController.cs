using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class ReviewController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
