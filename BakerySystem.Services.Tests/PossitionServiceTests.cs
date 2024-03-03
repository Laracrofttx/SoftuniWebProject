namespace BakerySystem.Services.Tests
{
	using BakerySystem.Web.Data;
	using BakerySystem.Services.Interfaces;
	using Microsoft.EntityFrameworkCore;

	using static DataBaseSeeder;

	public class PossitionServiceTests
	{
		private DbContextOptions<BakeryDbContext> dbOptions;
		private BakeryDbContext dbContext;

		private IPossitionService possitionService;


		[OneTimeSetUp]
		public void OneTimeSetUp()
		{

			this.dbOptions = new DbContextOptionsBuilder<BakeryDbContext>()
				.UseInMemoryDatabase("BakerySystemInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new BakeryDbContext(this.dbOptions);

			dbContext.Database.EnsureCreated();

			SeedDataBase(this.dbContext);

			this.possitionService = new PossitionService(this.dbContext);
			

		}

		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public async Task PossitionByIdShouldReturnTrueIfExists()
		{

			var possitionId = Possitions.Id;

			bool result = await this.possitionService.ExistByIdAsync(possitionId);

			Assert.That(result, Is.True);
		
		}
	}

}
