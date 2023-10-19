namespace BakerySystem.Web.Areas.Admin.ViewModels.Product
{
	using BakerySystem.Web.ViewModels.Product;
	public class ProductListingViewModel
	{
		public IEnumerable<ProductListingVIewModel> AllProducts { get; set; } = new List<ProductListingVIewModel>();
	}
}
