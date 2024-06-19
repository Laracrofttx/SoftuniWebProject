namespace BakerySystem.Web.ViewModels.Category
{
	using BakerySystem.Services.Mapping;

	using Data.Models;
	public class CategoryListingViewModel : IMapFrom<Category>
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
	}
}
