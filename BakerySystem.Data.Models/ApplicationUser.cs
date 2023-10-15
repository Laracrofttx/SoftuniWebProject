namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using Microsoft.AspNetCore.Identity;

	using static Common.EntityValidationConstants.User;

	public class ApplicationUser : IdentityUser<Guid>
	{

		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();

			this.UserName = Guid.NewGuid().ToString();
		}

		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; }

		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; }
	}


}
