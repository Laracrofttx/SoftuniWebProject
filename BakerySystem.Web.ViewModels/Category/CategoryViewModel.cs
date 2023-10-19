namespace BakerySystem.Web.ViewModels.Category
{
	using System.ComponentModel.DataAnnotations;
	using static BakerySystem.Common.EntityValidationConstants.Category;

	public class CategoryViewModel
	{

		public int Id { get; set; }


		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The field Name must be a string with a minimum length of {2}")]

		[Display(Name ="Category Name")]
		public string Name { get; set; } = null!;

		//public IEnumerable<CategoryViewModel> AllCategories { get; set; } = null!;
		

	}
}
