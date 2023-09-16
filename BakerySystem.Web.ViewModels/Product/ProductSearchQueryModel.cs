using System.ComponentModel.DataAnnotations;

namespace BakerySystem.Web.ViewModels.Product
{
	public class ProductSearchQueryModel
	{
		
		[Display(Name = "Name")] 
		public string SearchByName { get; set; } = null!;

		public ProductSorting Sorting { get; set; }

		public IEnumerable<ProductListingVIewModel> Products { get; set; } = null!;
	}
}
