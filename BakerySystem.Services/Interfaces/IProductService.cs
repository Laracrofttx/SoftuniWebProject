﻿namespace BakerySystem.Services.Interfaces
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Statistics;
	using BakerySystem.Web.ViewModels.Product;

	public interface IProductService
	{
		Task CreateProductAsync(ProductFormModel model);
		Task<bool> ExistByIdAsynch(int id);
		Task<IEnumerable<ProductListingVIewModel>> GetAllProductsAsync();
		Task<IEnumerable<ProductListingVIewModel>> GetAllProductsByIdAsync(int id);
		Task<Product> GetProductByIdAsynch(int id);
		Task<ProductDetailsServiceModel> ProductDetailsByIdAsynch(int id);
		Task<ProductFormModel> ProductForEditByIdAsync(int id);
		Task EditProductByIdAndFormModel(int id, ProductFormModel model);
		Task<ProductForDeleteViewModel> ProductForDeleteByIdAsynch(int productId);
		Task DeleteProductByIdAsynch(int productId);
		Task<StatisticServiceModel> GetStatisticsAsynch();
	}
}
