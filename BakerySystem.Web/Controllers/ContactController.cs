using BakerySystem.Services.Interfaces;
using BakerySystem.Web.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;

namespace BakerySystem.Web.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
			this.contactService = contactService;
        }

        public async Task<IActionResult> Contact()
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
