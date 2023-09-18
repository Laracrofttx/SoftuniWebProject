namespace BakerySystem.Web.ViewModels.Product
{
	using System.ComponentModel.DataAnnotations;

	
	public class ProductSearchQueryModel
	{
		public const int ProductsPerPage = 4;

		[Display(Name = "Name")]
		public string SearchByName { get; set; } = null!;

		public int CurrentPage { get; set; } = 1;

		public int TotalProducts { get; set; }

		public IEnumerable<ProductListingVIewModel> Products { get; set; } = null!;
	}
}
