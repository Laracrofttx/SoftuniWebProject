using BakerySystem.Web.ViewModels.Category;
using BakerySystem.Web.ViewModels.Product;

namespace BakerySystem.Web.ViewModels.Home
{
	public class ProductIndexViewModel
	{
		public ProductIndexViewModel()
		{
			this.Products = new HashSet<ProductListingVIewModel>();
			this.Categories = new HashSet<CategoryListingViewModel>();
		}
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public decimal Price { get; set; }

		public IEnumerable<ProductListingVIewModel> Products { get; set; } = null!;

		public IEnumerable<CategoryListingViewModel> Categories { get; set; } = null!;
	}
}
