namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.OrderDetails;
	public class OrderDetail
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

		[Required]
		[MaxLength(AddressMaxLength)]
		public string Address { get; set; } = null!;

		[Required]
		[MaxLength(PhoneNumberMaxLength)]
		public string PhoneNumber { get; set; } = null!;

		public int TotalPrice { get; set; }

		public int OrderId { get; set; }




	}
}
