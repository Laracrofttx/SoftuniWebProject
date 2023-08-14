namespace BakerySystem.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using static BakerySystem.Common.EntityValidationConstants.Products;

	public class Product
	{
		public Product()
		{
			this.ShoppingCart = new HashSet<ShoppingCart>();

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

		public Category Category { get; set; } = null!;
	    
		public ICollection<ShoppingCart> ShoppingCart { get; set; } = null!;
	}
}
