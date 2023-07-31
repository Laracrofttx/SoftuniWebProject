namespace BakerySystem.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using static BakerySystem.Common.EntityValidationConstants.Products;

	public class Products
	{
		public int Id { get; set; }

		[Required]
		[MinLength(NameMinLength)]
		[MinLength(NameMinLength)]
		public string Name = null!;

		public decimal Price { get; set; }

		public Category Category { get; set; } = null!;

	    

	}
}
