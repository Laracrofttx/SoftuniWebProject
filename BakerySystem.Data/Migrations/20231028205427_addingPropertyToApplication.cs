using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class addingPropertyToApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_WeAreHirings_WeAreHiringId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "PossitionId",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "WeAreHiringId",
                table: "JobApplications",
                newName: "PossitionIdId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_WeAreHiringId",
                table: "JobApplications",
                newName: "IX_JobApplications_PossitionIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_WeAreHirings_PossitionIdId",
                table: "JobApplications",
                column: "PossitionIdId",
                principalTable: "WeAreHirings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_WeAreHirings_PossitionIdId",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "PossitionIdId",
                table: "JobApplications",
                newName: "WeAreHiringId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_PossitionIdId",
                table: "JobApplications",
                newName: "IX_JobApplications_WeAreHiringId");

            migrationBuilder.AddColumn<int>(
                name: "PossitionId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_WeAreHirings_WeAreHiringId",
                table: "JobApplications",
                column: "WeAreHiringId",
                principalTable: "WeAreHirings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
