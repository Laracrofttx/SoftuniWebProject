using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class OrderDetailsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
