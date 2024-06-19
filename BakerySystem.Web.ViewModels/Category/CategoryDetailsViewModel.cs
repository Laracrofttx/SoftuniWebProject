namespace BakerySystem.Web.ViewModels.Category
{
	using BakerySystem.Web.ViewModels.Product;
	public class CategoryDetailsViewModel : CategoryListingViewModel
	{
		public IEnumerable<ProductListingVIewModel> ProductsByCategory { get; set; } = null!;
	}
}
