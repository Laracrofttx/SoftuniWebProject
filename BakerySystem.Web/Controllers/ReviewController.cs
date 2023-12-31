﻿namespace BakerySystem.Web.Controllers
{
	using BakerySystem.Data.Models;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Review;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using System.Linq;

	public class ReviewController : Controller
	{
		private readonly BakeryDbContext dbContext;
		//private readonly IReviewService reviewService;


		public ReviewController(BakeryDbContext dbContext) /*IReviewService reviewService*/
		{
			this.dbContext = dbContext;
			//this.reviewService = reviewService;
		}

		[HttpGet]
		public async Task<IActionResult> Add()
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
