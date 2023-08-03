using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
