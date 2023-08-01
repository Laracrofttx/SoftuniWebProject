using System.ComponentModel.DataAnnotations;


namespace BakerySystem.Data.Models
{
	public class Review
	{
		public int Id { get; set; }

		public Product ProductReview { get; set; } = null!;

		public string FeedBack { get; set; } = null!;
	}
}
