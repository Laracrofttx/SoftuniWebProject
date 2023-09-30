using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.Data;
using BakerySystem.Web.ViewModels.Review;


namespace BakerySystem.Services
{
	public class ReviewService : IReviewService
	{
		private readonly BakeryDbContext dbContext;

		public ReviewService(BakeryDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddReview(ReviewFormModel review)
		{

			//var feedBack = new Review()
			//{

			//	Id = review.Id,
			//	 = review.UserName,
			//	Review = review.Review
			//};

			//await this.dbContext.Reviews.AddAsync(feedBack);
			//await this.dbContext.SaveChangesAsync();

		}
	}
}
