using BakerySystem.Web.ViewModels.Review;

namespace BakerySystem.Services.Interfaces
{
	public interface IReviewService
	{
		Task AddReview(ReviewFormModel model);

		Task<IEnumerable<ReviewFormModel>> AllReviewsAsync();

	}
}
