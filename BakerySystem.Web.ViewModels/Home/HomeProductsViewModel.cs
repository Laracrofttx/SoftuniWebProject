using BakerySystem.Data.Models;

namespace BakerySystem.Web.ViewModels.Home
{
	public class HomeProductsViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

    }
}
