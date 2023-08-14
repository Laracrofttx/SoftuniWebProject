using BakerySystem.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace BakerySystem.Web.ViewModels.ShoppingCart
{
	public class ShoppingCartViewModel
	{
		public ShoppingCartItem ShoppingCart { get; set; }

		public decimal ShoppingCartTotal { get; set; }
	}
}
