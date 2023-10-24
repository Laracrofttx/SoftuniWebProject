using BakerySystem.Data.Models;
using BakerySystem.Services.Interfaces;
using BakerySystem.Web.Data;
using BakerySystem.Web.ViewModels.JoinUs;

namespace BakerySystem.Services
{
	public class PossitionService : IPossitionService
	{

		private readonly BakeryDbContext dbContext;

        public PossitionService(BakeryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPossitionAsync(PossitionFormModel possition)
		{

			var possitionType = new WeAreHiring
			{
				Id = possition.Id,
				PositionName = possition.PossitionName,
				ImageUrl = possition.ImageUrl,
				JobDescription = possition.PossitionDescription,
				Salary = possition.Salary,

			};

			await this.dbContext.WeAreHirings.AddAsync(possitionType);
			await this.dbContext.SaveChangesAsync();

		}
	}
}
