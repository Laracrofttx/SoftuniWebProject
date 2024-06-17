namespace BakerySystem.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Review;
	using BakerySystem.Services.Interfaces;

	public class ReviewController : Controller
	{
		private readonly BakeryDbContext dbContext;
		private readonly IReviewService reviewService;
		public ReviewController(BakeryDbContext dbContext, IReviewService reviewService)
		{
			this.dbContext = dbContext;
			this.reviewService = reviewService;
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(ReviewFormModel model)
		{

			if (!ModelState.IsValid)
			{
				return View(model);
			}
			
			try
			{
				await this.reviewService.AddReview(model);

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
		public async Task<IActionResult> All()
		{
			IEnumerable<ReviewFormModel> reviews = await this.reviewService.AllReviewsAsync();

			return View(reviews);
		}
	}
}
