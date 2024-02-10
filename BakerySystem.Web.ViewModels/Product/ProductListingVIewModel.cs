namespace BakerySystem.Web.ViewModels.Product
{
	using Data.Models;

	using BakerySystem.Services.Mapping;
	using AutoMapper;

	public class ProductListingVIewModel : IMapFrom<Product>, IHaveCustomMappings
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public decimal Price { get; set; }

		public string ImageUrl { get; set; } = null!;

		public string Description { get; set; } = null!;

		public string Category { get; set; } = null!;

		public int CategoryId { get; set; }

		public IEnumerable<Product> Products { get; set; } = null!;

		public void CreateMappings(IProfileExpression configuration)
		{
			configuration.CreateMap<ProductListingVIewModel, Product>();
		}

		
	}
}
