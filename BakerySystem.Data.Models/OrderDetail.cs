using System.ComponentModel.DataAnnotations;


namespace BakerySystem.Data.Models
{

	public class OrderDetail
	{
		[Key]
		public int Id { get; set; }

		public int TotalPrice { get; set; }

		public int OrderId { get; set; }

		public virtual Order OrderDetails { get; set; } = null!;

		public int ProductId { get; set; }

		public virtual Product ProductDetails { get; set; } = null!;


	}
}
