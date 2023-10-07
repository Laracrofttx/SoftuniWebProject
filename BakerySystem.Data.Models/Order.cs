namespace BakerySystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;


	public class Order
	{
		[Key]
		public int Id { get; set; }

		public string ProductName { get; set; } = null!;

		public decimal ProductPrice { get; set; }

		public string ImageUrl { get; set; } = null!;

		public int ProductQuantity { get; set; }

		public decimal TotalAmount { get; set; }

		public virtual Product Product { get; set; } = null!;


	}
}
