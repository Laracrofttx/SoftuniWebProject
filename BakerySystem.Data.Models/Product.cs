namespace BakerySystem.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	

	using static BakerySystem.Common.EntityValidationConstants.Products;

	public class Product
	{
		public Product()
		{
			
			this.ShoppingCartItems = new HashSet<ShoppingCartItem>();
			
		}

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

		public int CategoryId { get; set; }

		public virtual Category Category { get; set; } = null!;
	    
		public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;

		
	}
}
