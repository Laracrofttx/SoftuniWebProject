﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class newPropertyToTheProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAvailable",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAvailable",
                table: "Products");
        }
    }
}
