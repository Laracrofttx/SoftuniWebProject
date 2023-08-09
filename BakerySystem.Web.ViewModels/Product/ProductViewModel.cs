

namespace BakerySystem.Web.ViewModels.Product
{
	public class ProductViewModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string Description { get; set; } = null!;

		public int CategoryId { get; set; }
	}
}
