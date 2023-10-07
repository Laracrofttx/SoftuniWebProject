using BakerySystem.Data.Models;
using BakerySystem.Web.ViewModels.Order;

namespace BakerySystem.Services.Interfaces
{
	public interface IOrderService
	{
		public Task AddToOrder(int id);


	}


}
