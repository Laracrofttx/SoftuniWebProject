namespace BakerySystem.Web.ViewModels.Home
{
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Product;
	public class ProductIndexViewModel
	{
		public ProductIndexViewModel()
		{
			this.Products = new HashSet<ProductSearchQueryModel>();
			this.Categories = new HashSet<CategoryListingViewModel>();
		}
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public decimal Price { get; set; }

		public IEnumerable<ProductSearchQueryModel> Products { get; set; } = null!;

		public IEnumerable<CategoryListingViewModel> Categories { get; set; } = null!;

		public decimal DiscoutPrice { get; set; }




	}
}
