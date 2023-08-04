namespace BakerySystem.Services.Interfaces
{
	using BakerySystem.Data.Models;
	using BakerySystem.Web.ViewModels.Home;

	public interface IProductService
	{
		Task<IEnumerable<IndexViewModel>> AllProductsAsync();
	}
}
