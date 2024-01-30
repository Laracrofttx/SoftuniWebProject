namespace BakerySystem.Services.Interfaces
{
	using BakerySystem.Data.Models;
	using BakerySystem.Web.ViewModels.JoinUs;
	public interface IPossitionService
	{
		Task AddPossitionAsync(PossitionFormModel possition);

		Task<bool> ExistByIdAsync(int id);

		Task<IEnumerable<PossitionListingViewModel>> GetAllPossitionsAsync();

		Task<PossitionDetailsServiceModel> PossitionDetailsAsync(int id);

		Task<PossitionFormModel> GetPossitionForEditByIdAsync(int id);

		Task EditPossitionByIdAndFormModelAsync(int id, PossitionFormModel possition);

		Task<PossitionDeleteViewModel> PossitionForDeleteByIdAsync(int id);

		Task DeletePossitionByIdAsync(int id);

		Task<WeAreHiring> GetPossitionIdAsync(int id);

		Task Apply(ApplyViewModel apply);
	}
}
