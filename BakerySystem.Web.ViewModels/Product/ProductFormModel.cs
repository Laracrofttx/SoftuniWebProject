namespace BakerySystem.Web.ViewModels.Product
{
	using System.ComponentModel.DataAnnotations;
	using Data.Models;
	using BakerySystem.Services.Mapping;
	using static BakerySystem.Common.EntityValidationConstants.Products;
	using AutoMapper;

	public class ProductFormModel : IMapFrom<Product>, IHaveCustomMappings
	{
		public ProductFormModel()
		{
			this.Categories = new HashSet<ProductCategoryViewModel>();
		}

		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The field Name must be a string with a minimum length of {2}")]
		public string Name { get; set; } = null!;

		[Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
		public decimal Price { get; set; }

		[Required]
		[Display(Name = "Image")]
		[Url]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[StringLength(int.MaxValue, MinimumLength = DescriptionMinLength, ErrorMessage = "The field Description must be a string with a minimum length of {2}")]
		public string Description { get; set; } = null!;

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<ProductCategoryViewModel> Categories { get; set; } = null!;

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<ProductFormModel, Product>();
		}
	}
}
