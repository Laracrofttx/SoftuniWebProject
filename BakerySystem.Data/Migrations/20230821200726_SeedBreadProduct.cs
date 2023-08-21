using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class SeedBreadProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
				table: "Products",
				columns: new[] { "Id", "Name", "Price", "ImageUrl", "CategoryId", "Description" },
				values: new object[,]
				{
					{ 1, "Classic White Bread", "2.00", "classic white bread.jpg", 1, "A usually baked and leavened food made of a mixture whose basic constituent is flour or meal."},
					{ 2, "Soda Bread", "3.00", "soda-bread.jpg", 1, "The unique texture of soda bread is a result of the reaction between the acidic sour milk and baking soda"},
					{ 3, "Baguettes", "3.00", "Baguette.jpg", 1, "A long, narrow French loaf"},
					{ 4, "Bagels", "4.00", "Bagel.jpg", 1, "Doughnut-shaped yeast-leavened roll that is characterized by a crisp, shiny crust and a dense interior." },
					{ 5, "Bread Rolls", "4.00", "bread rolls.jpg", 1, "Small, often round loaf of bread served as a meal accompaniment." },
					{ 6, "Challah", "4.00", "challah.jpg", 1, "A special bread of Ashkenazi Jewish origin." }
				});

		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
