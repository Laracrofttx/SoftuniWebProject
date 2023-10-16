namespace BakerySystem.Services.Interfaces
{
	public interface IUserService
	{
		Task<string> GetFullNameByEmailAsync(string email);
	}
}
