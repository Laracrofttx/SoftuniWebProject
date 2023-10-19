namespace BakerySystem.Web.Areas.Admin.Controllers
{
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.ViewModels.User;
	using Microsoft.AspNetCore.Mvc;
	public class UserController : BaseAdminController
	{
		private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

		[Route("User/All")]
        public async Task<IActionResult> All()
		{

			var users = await this.userService.AllAsync();


			return View(users);
		}
	}
}
