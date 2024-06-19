namespace BakerySystem.Services
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Review;
	using Microsoft.EntityFrameworkCore;
	public class ReviewService : IReviewService
	{
		private readonly BakeryDbContext dbContext;

		public ReviewService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task AddReview(ReviewFormModel review)
		{
			var feedBack = new Review()
			{

				Id = review.Id,
				UserName = review.UserName,
				FeedBack = review.FeedBack
			};

			await this.dbContext.Reviews.AddAsync(feedBack);
			await this.dbContext.SaveChangesAsync();
		}
		public async Task<IEnumerable<ReviewFormModel>> AllReviewsAsync()
		{
			IEnumerable<ReviewFormModel> reviews =
				await this.dbContext
				.Reviews
				.Select(r => new ReviewFormModel
				{
					Id = r.Id,
					UserName = r.UserName,
					FeedBack = r.FeedBack
				})
				.ToArrayAsync();

			return reviews;
		}
	}
}
