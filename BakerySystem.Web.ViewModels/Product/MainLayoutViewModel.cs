namespace BakerySystem.Web.ViewModels.Product
{
	public class MainLayoutViewModel
	{
		public string pageTitle { get; set; } = null!;

		public int CategoryId { get; set; }

		public IEnumerable<ProductCategoryViewModel> Category { get; set; } = null!;
	}
}
