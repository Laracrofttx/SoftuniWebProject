namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Data.Models;
	using BakerySystem.Web.ViewModels.User;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Caching.Memory;

    public class UserController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMemoryCache memoryCache;


        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache)
        {
			this._signInManager = signInManager;
			this._userManager = userManager;
			this.memoryCache = memoryCache;
				
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
			await this._userManager.SetUserNameAsync(user, model.UserName);

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

		[HttpGet]
		public async Task<IActionResult> Login(string? returnUrl = null)
		{
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			LoginFormModel model = new LoginFormModel()
			{

				ReturnUrl = returnUrl


			};

			return this.View(model);
		
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return this.View(model);
			}

			var result = await this._signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
		     

			if (!result.Succeeded)
			{
				this.TempData["ErrorMessage"] = "There was a error while loggin you in! Please try again later or contact an administrator.";

				return this.View(model);
			}

			return this.Redirect(model.ReturnUrl ?? "/Home/Index");
		}
	}
}
