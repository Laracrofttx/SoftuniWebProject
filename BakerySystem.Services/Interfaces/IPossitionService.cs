using BakerySystem.Web.ViewModels.JoinUs;

namespace BakerySystem.Services.Interfaces
{
	public interface IPossitionService
	{
		Task AddPossitionAsync(PossitionFormModel possition);
	}
}
