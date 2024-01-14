namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static BakerySystem.Common.EntityValidationConstants.DailyOfferts;
	public class DailyOffert
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		public decimal Price { get; set; }
	}
}
