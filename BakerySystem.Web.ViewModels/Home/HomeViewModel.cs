using BakerySystem.Data.Models;

namespace BakerySystem.Web.ViewModels.Home
{
	public class HomeViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;

		public string ImageUrl { get; set; } = null!;

    }
}
