namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	public class ReviewController : Controller
	{
		public async Task<IActionResult> Add()
		{
			return View();
		}
	}
}
