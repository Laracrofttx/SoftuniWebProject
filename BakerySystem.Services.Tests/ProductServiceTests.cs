namespace BakerySystem.Services.Tests
{
	using BakerySystem.Data.Models;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Web.Data;
	using Microsoft.EntityFrameworkCore;

	using static DataBaseSeeder;
	public class ProductServiceTests
	{
		private DbContextOptions<BakeryDbContext> dbOptions;
		private BakeryDbContext dbContext;

		private  IProductService productService;
		private  ICategoryService categoryService;

		

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{

			this.dbOptions = new DbContextOptionsBuilder<BakeryDbContext>()
				.UseInMemoryDatabase("BakerySystemInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.dbContext = new BakeryDbContext(this.dbOptions);

			dbContext.Database.EnsureCreated();

			SeedDataBase(this.dbContext);

			this.productService = new ProductService(this.dbContext);
			this.categoryService = new CategoryService(this.dbContext);

		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public async Task ProductExistByIdShouldReturnTrueWhenExist()
		{
			int productId = Products.Id;

			bool result = await this.productService.ExistByIdAsynch(productId);

			Assert.That(result, Is.True);
		
		}

		[Test]
		public async Task CategoryExistByIdShouldReturnTrueWhenExist()
		{
			int categoryId = Categories.Id;

			bool result = await this.categoryService.ExistByIdAsync(categoryId);

			Assert.That(result, Is.True);
		}

		
	}
}