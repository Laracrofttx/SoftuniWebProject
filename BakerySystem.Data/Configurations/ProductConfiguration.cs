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

			product = new Product
			{
				Id = 1,
				Name = "White Bread",
				ImageUrl = "https://media.istockphoto.com/id/995038782/photo/heap-of-bread.jpg?s=612x612&w=0&k=20&c=UoAcNzbbDx2ybqoEZWBaxBdy73W2NN3km8MKSci0cHk="


			};

			products.Add(product);

			product = new Product
			{
				Id = 2,
				Name = "Banana Muffin",
				ImageUrl = "https://hellofrozenbananas.com/wp-content/uploads/2022/08/Gluten-Free-Muffins.jpg"
			};
			
			products.Add(product);

			product = new Product
			{
				Id = 3,
				Name = "Chocolate Cake",
				ImageUrl = "https://sugarfreelondoner.com/wp-content/uploads/2020/12/sugar-free-birthday-cake-chocolate-1200.jpg"

			};

			products.Add(product);

			return products.ToArray();

		
		}
	}
}
