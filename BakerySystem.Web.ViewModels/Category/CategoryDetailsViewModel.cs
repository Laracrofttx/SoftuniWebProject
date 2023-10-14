using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Web.ViewModels.Category
{
	public class CategoryDetailsViewModel : CategoryListingViewModel
	{
		public IEnumerable<ProductListingVIewModel> ProductsByCategory { get; set; } = null!;

		
	}
}
