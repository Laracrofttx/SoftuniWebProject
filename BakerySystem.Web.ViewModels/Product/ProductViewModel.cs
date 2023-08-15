using BakerySystem.Web.ViewModels.Category;

namespace BakerySystem.Web.ViewModels.Product
{
	public class ProductViewModel
	{

		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

		public int CategoryId { get; set; }
		public IEnumerable<CategoryViewModel> Categories { get; set; }
		
	}
}
