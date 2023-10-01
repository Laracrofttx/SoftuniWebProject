namespace BakerySystem.Web.ViewModels.Review
{
	public class ReviewListingViewModel
	{
		public int Id { get; set; }

		public string UserName { get; set; } = null!;

		public string FeedBack { get; set; } = null!;

		public IEnumerable<ReviewFormModel> Reviews { get; set; } = null!;
	}
}
