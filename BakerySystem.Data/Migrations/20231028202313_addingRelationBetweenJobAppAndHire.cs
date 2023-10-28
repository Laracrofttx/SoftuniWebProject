using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerySystem.Data.Migrations
{
    public partial class addingRelationBetweenJobAppAndHire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PossitionId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeAreHiringId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_WeAreHiringId",
                table: "JobApplications",
                column: "WeAreHiringId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_WeAreHirings_WeAreHiringId",
                table: "JobApplications",
                column: "WeAreHiringId",
                principalTable: "WeAreHirings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "PossitionId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "WeAreHiringId",
                table: "JobApplications");
        }
    }
}
