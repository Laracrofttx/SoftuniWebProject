namespace BakerySystem.Services.Interfaces
{
	using BakerySystem.Data.Models;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Home;
	using BakerySystem.Web.ViewModels.Product;

	public interface IProductService
	{
		
		Task CreateProductAsync(ProductFormModel model);

		Task<bool> ExistByIdAsynch(int id);

		Task<ProductFormModel> ProductForEditByIdAsync(int id);

		Task EditProductByIdAndFormModel(int id, ProductFormModel model);

		
	}
}
