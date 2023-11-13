using BakerySystem.Data.Models;
using BakerySystem.Web.ViewModels.DailyOffer;

namespace BakerySystem.Services.Interfaces
{
	public interface IDailyOfferService
	{
		Task<IEnumerable<DailyOfferViewModel>> DailyOffer();
	}
}
