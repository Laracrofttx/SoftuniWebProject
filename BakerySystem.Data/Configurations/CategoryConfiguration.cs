using BakerySystem.Data.Models;
using BakerySystem.Data.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakerySystem.Data.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		private readonly CategorySeeder categorySeeder;

		public CategoryConfiguration()
		{
			this.categorySeeder= new CategorySeeder();
		}
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(this.categorySeeder.GenerateCategories().ToArray());
			
				
		}
	}
}
