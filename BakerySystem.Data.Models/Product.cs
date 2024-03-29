﻿namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static BakerySystem.Common.EntityValidationConstants.Products;

	public class Product
	{
		
		[Key]
		public int Id { get; set; }


		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }
		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(ImageUrlMaxLength)]
		public string ImageUrl { get; set; } = null!;

		public bool IsAvailable { get; set; }

		public int CategoryId { get; set; }

		public virtual Category Category { get; set; } = null!;
	    

		
	}
}
