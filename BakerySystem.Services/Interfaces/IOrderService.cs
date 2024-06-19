using BakerySystem.Web.ViewModels.Order;

namespace BakerySystem.Services.Interfaces
{
	public interface IOrderService
	{
		 Task CheckoutOrder(CheckoutViewModel order);
	}
}
