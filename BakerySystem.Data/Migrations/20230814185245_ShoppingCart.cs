using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class ShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Products_productsId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "productsId",
                table: "ShoppingCart",
                newName: "ProductsId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_productsId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Products_ProductsId",
                table: "ShoppingCart",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Products_ProductsId",
                table: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "ShoppingCart",
                newName: "productsId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_ProductsId",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_productsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Products_productsId",
                table: "ShoppingCart",
                column: "productsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
