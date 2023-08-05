namespace BakerySystem.Services.Interfaces
{

	using BakerySystem.Web.ViewModels.Home;

	public interface IProductService
	{
	  	Task<IEnumerable<HomeProductsViewModel>> AllProductsAsync();
	}
}
