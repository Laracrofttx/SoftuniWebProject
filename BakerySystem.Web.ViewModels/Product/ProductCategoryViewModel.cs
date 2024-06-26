﻿namespace BakerySystem.Web.ViewModels.Product
{
	using Data.Models;
	using BakerySystem.Services.Mapping;

	public class ProductCategoryViewModel : IMapFrom<Product>
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
	}
}
