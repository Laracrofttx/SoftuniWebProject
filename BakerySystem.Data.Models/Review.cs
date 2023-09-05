namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Review
	{
		public int Id { get; set; }

		public virtual Product ProductReview { get; set; } = null!;

		public string FeedBack { get; set; } = null!;
	}
}
