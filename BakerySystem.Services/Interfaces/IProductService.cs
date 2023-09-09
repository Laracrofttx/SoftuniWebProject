namespace BakerySystem.Services.Interfaces
{
	using BakerySystem.Data.Models;
	using BakerySystem.Web.ViewModels.Category;
	using BakerySystem.Web.ViewModels.Home;
	using BakerySystem.Web.ViewModels.Product;

	public interface IProductService
	{
		Task<IEnumerable<HomeViewModel>> AllProductsAsync();

		Task<IEnumerable<ProductListingVIewModel>> All();

		Task<IEnumerable<ProductViewModel>> AllEasterBreads();

		//Product GetProductById(int productId); 
	}
}
