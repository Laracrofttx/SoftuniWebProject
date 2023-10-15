namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Data.Models;
	using BakerySystem.Web.ViewModels.User;

	public class UserController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUserStore<ApplicationUser> _userStore;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
			this._signInManager = signInManager;
			this._userManager = userManager;
				
        }

        [HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{

			if (!ModelState.IsValid)
			{

				return View(model);

			}

			ApplicationUser user = new ApplicationUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,

			};

			await this._userManager.SetEmailAsync(user, model.Email);
			await this._userManager.SetUserNameAsync(user,string.Join(" ", model.FirstName + model.LastName));

			IdentityResult result = 
				await this._userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				return View(model);
			}
				await this._signInManager.SignInAsync(user, false);

				return RedirectToAction("Index", "Home");
		}
	}
}
