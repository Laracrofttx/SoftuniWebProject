namespace BakerySystem.Web.ViewModels.Product
{
	using System.ComponentModel.DataAnnotations;
	public class ProductForDeleteViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public decimal Price { get; set; }

		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;
	}
}
