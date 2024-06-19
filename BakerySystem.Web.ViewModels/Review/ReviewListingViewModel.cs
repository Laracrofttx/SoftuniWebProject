namespace BakerySystem.Web.ViewModels.Review
{
	public class ReviewListingViewModel
	{
		public int Id { get; set; }
		public string UserName { get; set; } = null!;
		public DateTime PostedOn { get; set; }
		public string FeedBack { get; set; } = null!;
		public IEnumerable<ReviewFormModel> Reviews { get; set; } = null!;
	}
}
