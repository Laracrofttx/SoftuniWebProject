using BakerySystem.Data.Models;
using BakerySystem.Web.ViewModels.Order;

namespace BakerySystem.Services.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderViewModel>> OrderHistory();

		Task<IEnumerable<OrderViewModel>> Order();



	}


}
