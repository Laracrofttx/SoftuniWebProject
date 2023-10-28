namespace BakerySystem.Services.Interfaces
{
	using Microsoft.AspNetCore.Http;
	public interface IBufferedFileUploadService
	{
		Task<bool> UploadFile(IFormFile file);
	}
}
