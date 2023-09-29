using System.ComponentModel.DataAnnotations;

namespace BakerySystem.Web.ViewModels.Product
{
	public class ProductForDeleteViewModel
	{
		public string Name { get; set; } = null!;

		public decimal Price { get; set; }

		[Display(Name="Image Link")]
		public string ImageUrl { get; set; } = null!;

	}
}
