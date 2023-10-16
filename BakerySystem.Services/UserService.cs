using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BakerySystem.Services
{
	public class UserService : IUserService
	{
		private readonly BakeryDbContext dbContext;

        public UserService(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
		{
			ApplicationUser? user = await dbContext
				.Users
				.FirstOrDefaultAsync(u => u.Email == email);

			if (user == null)
			{
				return string.Empty;
			}

			return $"{user.FirstName} {user.LastName}";
		}
	}
}
