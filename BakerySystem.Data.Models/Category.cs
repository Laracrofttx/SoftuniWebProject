namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.Diagnostics;
	using static Common.EntityValidationConstants.Category;
	public class Category
	{
		public Category()
		{
			
			this.Products = new HashSet<Product>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public bool IsAvailable { get; set; }

		public virtual ICollection<Product> Products { get; set; } = null!;
       
    }
}