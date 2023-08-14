using BakerySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakerySystem.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(this.GenerateProducts());
			
		}


		private Product[] GenerateProducts()
		{

			ICollection<Product> products = new HashSet<Product>();

			Product product;


			product = new Product()
			{

				Id = 1,
				Name = "Classic White Bread",
				Price = 2.00m,
				Description = "A usually baked and leavened food made of a mixture whose basic constituent is flour or meal.",
				ImageUrl = "classic white bread.jpg",
				CategoryId = 1,

			};
			products.Add(product);


			product = new Product()
			{

				Id = 2,
				Name = "Soda Bread",
				Price = 3.00m,
				Description = "The unique texture of soda bread is a result of the reaction between the acidic sour milk and baking soda",
				ImageUrl = "soda bread.jpg",
				CategoryId = 1,

			};
			products.Add(product);


			product = new Product()
			{

				Id = 3,
				Name = "Baguettes",
				Price = 3.00m,
				Description = "A long, narrow French loaf.",
				ImageUrl = "Baguette.jpg",
				CategoryId = 1,
			};
			products.Add(product);

			product = new Product()
			{
				Id = 4,
				Name = "Bagels",
				Price = 4.00m,
				Description = "Doughnut-shaped yeast-leavened roll that is characterized by a crisp, shiny crust and a dense interior.",
				ImageUrl = "Bagel.jpg",
				CategoryId = 1,


			};
			products.Add(product);

			product = new Product()
			{

				Id = 5,
				Name = "Bread Rolls",
				Price = 4.00m,
				Description = "Small, often round loaf of bread served as a meal accompaniment ",
				ImageUrl = "bread rolls.jpg",
				CategoryId = 1,

			};
			products.Add(product);

			product = new Product()
			{
				Id = 6,
				Name = "Challah",
				Price = 4.00m,
				Description = "A special bread of Ashkenazi Jewish origin",
				ImageUrl = "challah.jpg",
				CategoryId = 1,


			};
			products.Add(product);

	

			return products.ToArray();

		}


	}



}
