namespace BakerySystem.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using static BakerySystem.Common.EntityValidationConstants.ContactUs;
	public class ContactUs
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(FullNameMaxLength)]
		public string FullName { get; set; } = null!;

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = null!;

		[Required]
		[MaxLength(EmailMaxLength)]
		public string Email { get; set; } = null!;

		[Required]
		[MaxLength(MessageMaxLength)]
		public string Message { get; set; } = null!;
	}
}
