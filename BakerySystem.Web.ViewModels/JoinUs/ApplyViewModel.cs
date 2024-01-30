using System.ComponentModel.DataAnnotations;

namespace BakerySystem.Web.ViewModels.JoinUs
{
	public class ApplyViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Your Name")]
		public string FullName { get; set; } = null!;

		[Display(Name = "Email address")]
		public string EmailAddress { get; set; } = null!;

		[Display(Name = "Years of experience")]
		public string Experience { get; set; } = null!;

		[Display(Name = "Tell us more about yourself")]
		public string SelfDescription { get; set; } = null!;

		
	}
}
