namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.Contact;

	public class ContactController : Controller
	{
		private readonly IContactService contactService;

		public ContactController(IContactService contactService)
		{
			this.contactService = contactService;
		}

		public IActionResult Contact()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Contact(ContactViewModel mesage)
		{

			try
			{
				await this.contactService.Contact(mesage);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occured!");
				return View(mesage);
			}



			return RedirectToAction("Index", "Home");
		}
	}
}
