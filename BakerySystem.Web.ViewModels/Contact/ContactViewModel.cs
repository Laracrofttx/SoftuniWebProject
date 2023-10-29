using System.ComponentModel.DataAnnotations;

namespace BakerySystem.Web.ViewModels.Contact
{
	public class ContactViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Full name")]
		public string FullName { get; set; } = null!;

		[Display(Name = "Email address")]
		public string EmailAddress { get; set; } = null!;

		[Display(Name = "Phone number")]
		public string Phonenumber { get; set; } = null!;

		public string Message { get; set; } = null!;
	}
}
