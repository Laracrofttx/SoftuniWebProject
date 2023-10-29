namespace BakerySystem.Services.Interfaces
{
	using BakerySystem.Web.ViewModels.Contact;
	public interface IContactService
	{
		Task Contact(ContactViewModel contact);
	}
}
