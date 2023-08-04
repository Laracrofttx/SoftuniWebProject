namespace BakerySystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using BakerySystem.Data.Models;
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(this.GenerateCategories());

		}
		private Category[] GenerateCategories()
		{
			ICollection<Category> categories = new HashSet<Category>();

			Category category;

			category = new Category()
			{
				Id = 1,
				Name = "Bread",
				Description = "The most common type of bread in many countries."

			};
			categories.Add(category);

			category = new Category()
			{
				Id = 2,
				Name = "Muffins",
				Description = "An individually portioned baked product."

			};
			categories.Add(category);

			category = new Category()
			{
				Id = 3,
				Name = "Cakes",
				Description = "The distinction between these two broad categories of cake is in the fat content. Foam cakes have little to no fat, and usually have a larger proportion of egg."



			};
			categories.Add(category);

			return categories.ToArray();




		}
	}
}
