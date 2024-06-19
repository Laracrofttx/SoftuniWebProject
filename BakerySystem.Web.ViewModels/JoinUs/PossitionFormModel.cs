namespace BakerySystem.Web.ViewModels.JoinUs
{
	using System.ComponentModel.DataAnnotations;
	public class PossitionFormModel
	{
		public int Id { get; set; }

		[Display(Name = "Possition")]
		public string PossitionName { get; set; } = null!;

		[Display(Name = "Image")]
		public string ImageUrl { get; set; } = null!;
		public decimal Salary { get; set; }

		[Display(Name = "Description")]
		public string PossitionDescription { get; set; } = null!;
	}
}
