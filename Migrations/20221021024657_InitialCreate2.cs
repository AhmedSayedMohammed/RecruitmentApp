using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentApp.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_userId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_userId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "JobApplications");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_userId",
                table: "Vacancies",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Users_userId",
                table: "Vacancies",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Users_userId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_userId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Vacancies");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_userId",
                table: "JobApplications",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_userId",
                table: "JobApplications",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
