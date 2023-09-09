namespace BakerySystem.Web.ViewModels.Product
{
	public class ProductListingVIewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public decimal Price { get; set; }

		public string ImageUrl { get; set; } = null!;

		public string Description { get; set; } = null!;

	}
}
