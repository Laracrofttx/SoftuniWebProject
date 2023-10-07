namespace BakerySystem.Web.ViewModels.Order
{
	public class OrderViewModel
	{
		public int OrderId { get; set; }

		public string ProductName { get; set; } = null!;

		public decimal ProductPrice { get; set; }

		public string ImageUrl { get; set; } = null!;

		public decimal TotalAmount { get; set; }

		public int Quantity { get; set; }

		

	}
}
