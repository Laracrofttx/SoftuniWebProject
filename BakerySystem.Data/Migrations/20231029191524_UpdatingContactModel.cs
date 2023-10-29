using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class UpdatingContactModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ContactUs",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ContactUs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactUs");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "ContactUs",
                newName: "Address");

           
        }
    }
}
