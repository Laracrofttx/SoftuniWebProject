namespace BakerySystem.Services
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.Contact;
	using System.Threading.Tasks;

	public class ContactService : IContactService
	{
		private readonly BakeryDbContext dbContext;

        public ContactService(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Contact(ContactViewModel contact)
		{
			var message = new ContactUs
			{

				Id = contact.Id,
				FullName = contact.FullName,
				PhoneNumber = contact.Phonenumber,
				Email = contact.EmailAddress,
				Message = contact.Message,

			};

			await this.dbContext.ContactUs.AddAsync(message);
			await this.dbContext.SaveChangesAsync();
		}
		
	}
}
