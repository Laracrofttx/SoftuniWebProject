using BakerySystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using Category = BakerySystem.Data.Models.Category;

namespace BakerySystem.Data.Seeding
{
	public class CategorySeeder
	{
		
		internal Category[] GenerateCategories()
		{

			ICollection<Category> categories = new HashSet<Category>();

			Category currentCategory;

			currentCategory = new Category()
			{

				Id = 1,
				Name = "Breads",
				Description = "",
				

			};
			categories.Add(currentCategory);

			currentCategory = new Category()
			{

				Id = 2,
				Name = "Easter Breads",
				Description = "",


			};
			categories.Add(currentCategory);

			currentCategory = new Category()
			{

				Id = 3,
				Name = "Sandwiches",
				Description = "",


			};
			categories.Add(currentCategory);

			currentCategory = new Category()
			{

				Id = 4,
				Name = "Muffins",
				Description = "",


			};
			categories.Add(currentCategory);

			
			return categories.ToArray();
		}
	}
}
