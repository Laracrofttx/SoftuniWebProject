using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Web.ViewModels.Home
{
	public class ProductIndexViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public decimal  Price { get; set; }

		public List<ProductListingVIewModel> Products { get; set; } = null!;
	}
}
