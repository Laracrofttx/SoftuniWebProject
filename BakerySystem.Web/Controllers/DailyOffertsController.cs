using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class DailyOffertsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
