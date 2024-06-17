using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.Data;
using BakerySystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Identity;
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


		public async Task<string> GetFullNameByIdAsync(string userId)
		{
			ApplicationUser? user = await this.dbContext
				.Users
				.FirstOrDefaultAsync(u => u.Id.ToString() == userId!);

			if (user == null)
			{ 
			
				return string.Empty;
			
			}

			return $"{user.FirstName} {user.LastName}";
		}


		public async Task<IEnumerable<UserViewModel>> AllAsync()
		{
			List<UserViewModel> users = await this.dbContext
				.Users
				.Select(u => new UserViewModel()
				{
					Email = u.Email,
					FullName = u.FirstName + " " + u.LastName,

				})
				.ToListAsync();


			return users;	
		}

		
	}
}
