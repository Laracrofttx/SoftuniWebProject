namespace BakerySystem.Web.ViewModels.JoinUs
{
	using BakerySystem.Data.Models;
	public class PossitionListingViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
		public decimal Salary { get; set; }
		public string JobDescription { get; set; } = null!;
		public IEnumerable<WeAreHiring> WeAreHiring { get; set; } = null!;
	}
}
