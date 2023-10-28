using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class addingRelationBetweenHiringAndJobApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeAreHiringId",
                table: "JobApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_WeAreHiringId",
                table: "JobApplications",
                column: "WeAreHiringId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_WeAreHirings_WeAreHiringId",
                table: "JobApplications",
                column: "WeAreHiringId",
                principalTable: "WeAreHirings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_WeAreHirings_WeAreHiringId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_WeAreHiringId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "WeAreHiringId",
                table: "JobApplications");
        }
    }
}
