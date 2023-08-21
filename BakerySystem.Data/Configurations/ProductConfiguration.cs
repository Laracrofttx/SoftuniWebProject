using BakerySystem.Data.Models;
using BakerySystem.Data.Seeding;
using BakerySystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BakerySystem.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		private readonly ProductSeeder productSeeder;

		public ProductConfiguration()
		{
			this.productSeeder = new ProductSeeder();
		}
		public void Configure(EntityTypeBuilder<Product> builder)
		{

			builder.HasData(this.productSeeder.GenerateProducts());

			
			
		}


		


	}



}
