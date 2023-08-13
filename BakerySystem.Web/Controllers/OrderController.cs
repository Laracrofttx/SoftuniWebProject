using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
