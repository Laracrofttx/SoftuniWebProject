namespace BakerySystem.Web.Controllers
{
	using System.Linq;

	using Microsoft.EntityFrameworkCore;
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Data.Models;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Review;

	public class ReviewController : Controller
	{
		private readonly BakeryDbContext dbContext;


		public ReviewController(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet]
		public IActionResult Add()
		{

			return View();

		}

		[HttpPost]
		public async Task<IActionResult> Add(ReviewFormModel model)
		{

			if (ModelState.IsValid)
			{

				return View(model);

			}

			try
			{
				Review feedBack = new Review()
				{
					UserName = model.UserName,
					PostedOn = model.PostedOn,
					FeedBack = model.FeedBack
				};

				await this.dbContext.Reviews.AddAsync(feedBack);
				await this.dbContext.SaveChangesAsync();
				return RedirectToAction("All", "Review");

			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occured!");

			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> All(ReviewFormModel model)
		{

			var allReviews = await this.dbContext
				.Reviews
				.Select(r => new ReviewListingViewModel()
				{
					Id = r.Id,
					UserName = r.UserName,
					FeedBack = r.FeedBack,


				})
				.ToArrayAsync();

			model.Reviews = allReviews;

			return View(model);
		}
	}
}
