namespace BakerySystem.Services
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using BakerySystem.Web.ViewModels.JoinUs;
	using Microsoft.EntityFrameworkCore;

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

		public async Task<bool> ExistByIdAsync(int id)
		{
			bool result = await this.dbContext
			.WeAreHirings
			.AnyAsync(p => p.Id == id);

			await dbContext.SaveChangesAsync();

			return result;
		}

		public async Task<IEnumerable<PossitionListingViewModel>> GetAllPossitionsAsync()
		{
			var allPossitions = await this.dbContext
				.WeAreHirings
				.OrderBy(x => x.Id)
				.Select(p => new PossitionListingViewModel
				{

					Id = p.Id,
					Title = p.PositionName,
					Salary = p.Salary,
					ImageUrl = p.ImageUrl,
					JobDescription = p.JobDescription,


				})
				.ToArrayAsync();

			return allPossitions;
		}

		public async Task<PossitionDetailsServiceModel> PossitionDetailsAsync(int id)
		{
			WeAreHiring possition = await this.dbContext
				.WeAreHirings
				.Where(p => p.Id == id)
				.FirstAsync();

			return new PossitionDetailsServiceModel()
			{

				Id = possition.Id,
				Title = possition.PositionName,
				Salary = possition.Salary,
				ImageUrl = possition.ImageUrl,
				JobDescription = possition.JobDescription,


			};
		}

		public async Task<PossitionFormModel> GetPossitionForEditByIdAsync(int id)
		{
			var possitionForEdit = await this.dbContext
				.WeAreHirings
				.FirstAsync(p => p.Id == id);

			return new PossitionFormModel()
			{
				Id = id,
				PossitionName = possitionForEdit.PositionName,
				Salary = possitionForEdit.Salary,
				ImageUrl = possitionForEdit.ImageUrl,
				PossitionDescription = possitionForEdit.JobDescription,

			};


		}
		public async Task EditPossitionByIdAndFormModelAsync(int id, PossitionFormModel possition)
		{
			WeAreHiring possitionForEdit = await dbContext.WeAreHirings
				.FirstAsync(p => p.Id == id);


			possitionForEdit.Id = possition.Id;
			possitionForEdit.PositionName = possition.PossitionName;
			possitionForEdit.Salary = possition.Salary;
			possitionForEdit.ImageUrl = possition.ImageUrl;
			possitionForEdit.JobDescription = possition.PossitionDescription;

			await dbContext.SaveChangesAsync();
		}

		public async Task<PossitionDeleteViewModel> PossitionForDeleteByIdAsync(int id)
		{
			var possitionForDelete = await this.dbContext
				.WeAreHirings
				.FindAsync(id);

			return new PossitionDeleteViewModel()
			{
				Id = id,
				JobTitle = possitionForDelete.PositionName,
				Salary = possitionForDelete.Salary,
				ImageUrl = possitionForDelete.ImageUrl,
				JobDescription = possitionForDelete.JobDescription,

			};
		}

		public async Task DeletePossitionByIdAsync(int id)
		{
			WeAreHiring possition = await this.dbContext
				.WeAreHirings
				.FirstAsync(p => p.Id == id);

			this.dbContext.Remove(possition);
			this.dbContext.SaveChanges();
		}

		public async Task Apply(ApplyViewModel apply)
		{
			var app = new JobApplication
			{

				Id = apply.Id,
				FullName = apply.FullName,
				EmailAddress = apply.EmailAddress,
				Experience = apply.Experience,
				SelfDescription = apply.SelfDescription,

			};

			await this.dbContext.JobApplications.AddAsync(app);
			await this.dbContext.SaveChangesAsync();
		}

		public async Task<WeAreHiring> GetPossitionIdAsync(int id)
		{
			var possition = await this.dbContext
				.WeAreHirings
				.Where(p => p.Id == id)
				.FirstOrDefaultAsync();

			return possition;
		}
	}
}
