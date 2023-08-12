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
                Name = "Bread",
                Price = 1,
                ImageUrl = "Bread.jpg",
                Description= "Description",
                CategoryId= 1

            };
            products.Add(product);

            
            product = new Product()
            {

                Id = 2,
                Name = "Easter Bread",
                Price = 2,
                ImageUrl = "EasterBread.jpg",
                Description= "Description",
                CategoryId = 2

            };
            products.Add(product);

            
            product = new Product()
            {

                Id = 3,
                Name = "Easter Bread",
                Price = 3,
                ImageUrl = "sandwich.jpg",
                Description= "Description",
                CategoryId = 3
            };
            products.Add(product);

         
            return products.ToArray();

        }

    }

    

}
