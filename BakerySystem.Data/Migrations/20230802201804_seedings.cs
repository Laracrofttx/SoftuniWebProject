using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class seedings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "The distinction between these two broad categories of cake is in the fat content. Foam cakes have little to no fat, and usually have a larger proportion of egg.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "There are two main types of cakes: butter cakes (also known as shortened cakes) and foam cakes. The distinction between these two broad categories of cake is in the fat content. Foam cakes have little to no fat, and usually have a larger proportion of egg.");
        }
    }
}
