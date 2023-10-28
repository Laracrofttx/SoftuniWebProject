namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static BakerySystem.Common.EntityValidationConstants.JobApplication;
	public class JobApplication
	{
       
        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(FullNameMaxLength)]
		public string FullName { get; set; } = null!;

		[Required]
		[MaxLength(EmailMaxLength)]
		public string EmailAddress { get; set; } = null!;

		[Required]
		public string Experience { get; set; } = null!;

		[Required]
		[MaxLength(SelfDescriptionMaxLength)]
		public string SelfDescription { get; set; } = null!;


	}
}
