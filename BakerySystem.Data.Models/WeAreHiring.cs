namespace BakerySystem.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using static BakerySystem.Common.EntityValidationConstants.WeAreHiring;

	public class WeAreHiring
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(PositionNameMaxLength)]
		public string PositionName { get; set; } = null!;

		[Required]
		public decimal Salary { get; set; }

		[Required]
		[MaxLength(JobDescriptionMaxLength)]
		public string JobDescription { get; set; } = null!;



	}
}
