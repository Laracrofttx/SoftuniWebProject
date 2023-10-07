using BakerySystem.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace BakerySystem.Web.ViewModels.ShoppingCart
{
	public class ShoppingCartViewModel
	{
		public CartItem ShoppingCart { get; set; } = null!;

		public decimal ShoppingCartTotal { get; set; }
	}
}
