using Product = BakerySystem.Data.Models.Product;

namespace BakerySystem.Data.Seeding
{
	class ProductSeeder
	{
		internal Product[] GenerateProducts()
		{


			ICollection<Product> products = new HashSet<Product>();

			Product currentProduct;


			currentProduct = new Product()
			{

				Id = 1,
				Name = "Classic White Bread",
				Price = 2.00m,
				ImageUrl = "classic white bread.jpg",
				CategoryId= 1,
				Description = "A usually baked and leavened food made of a mixture whose basic constituent is flour or meal.",



			};
			products.Add(currentProduct);


			currentProduct = new Product()
			{

				Id = 2,
				Name = "Soda Bread",
				Price = 3.00m,
				ImageUrl = "soda bread.jpg",
				CategoryId= 1,
				Description = "The unique texture of soda bread is a result of the reaction between the acidic sour milk and baking soda",



			};
			products.Add(currentProduct);


			currentProduct = new Product()
			{

				Id = 3,
				Name = "Baguettes",
				Price = 3.00m,
				ImageUrl = "Baguette.jpg",
				CategoryId= 1,
				Description = "A long, narrow French loaf.",
				

			};
			products.Add(currentProduct);

			currentProduct = new Product()
			{
				Id = 4,
				Name = "Bagels",
				Price = 4.00m,
				ImageUrl = "Bagel.jpg",
				CategoryId= 1,
				Description = "Doughnut-shaped yeast-leavened roll that is characterized by a crisp, shiny crust and a dense interior.",
				



			};
			products.Add(currentProduct);

			currentProduct = new Product()
			{

				Id = 5,
				Name = "Bread Rolls",
				Price = 4.00m,
				ImageUrl = "bread rolls.jpg",
				CategoryId= 1,
				Description = "Small, often round loaf of bread served as a meal accompaniment ",
				

			};
			products.Add(currentProduct);

			currentProduct = new Product()
			{
				Id = 6,
				Name = "Challah",
				Price = 4.00m,
				ImageUrl = "challah.jpg",
				CategoryId = 1,
				Description = "A special bread of Ashkenazi Jewish origin",
				

			};
			products.Add(currentProduct);


			return products.ToArray();



		}

	}
}
