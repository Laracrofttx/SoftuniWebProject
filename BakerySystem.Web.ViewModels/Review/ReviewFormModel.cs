namespace BakerySystem.Web.ViewModels.Review
{
	using System.ComponentModel.DataAnnotations;
	using static BakerySystem.Common.EntityValidationConstants.FeedBack;
	public class ReviewFormModel
	{
        public int Id { get; set; }

		[Required]
		[Display(Name = "User name")]
		public string UserName { get; set; } = null!;

		[Required]
		[Display(Name = "Share your experience with us")]
		[StringLength(FeedBackMaxLength, MinimumLength = FeedBackMinLength, ErrorMessage ="The field must contain at least {2} characters.")]
		public string FeedBack { get; set; } = null!
		public DateTime PostedOn { get; set; }
		public IEnumerable<ReviewListingViewModel> Reviews { get; set; } = null!;
	}
}
