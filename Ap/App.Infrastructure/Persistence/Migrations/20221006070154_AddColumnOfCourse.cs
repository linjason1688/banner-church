using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnOfCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PastoralId",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "ClassContext",
                table: "Course",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "ClassContext");

            migrationBuilder.AddColumn<string>(
                name: "GraduationQualification",
                table: "Course",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "GraduationQualification");

            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                table: "Course",
                type: "bigint",
                maxLength: 200,
                nullable: false,
                defaultValue: 0L,
                comment: "OrganizationId");

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequiement",
                table: "Course",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "SpecialRequiement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassContext",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "GraduationQualification",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "SpecialRequiement",
                table: "Course");

            migrationBuilder.AddColumn<long>(
                name: "PastoralId",
                table: "Course",
                type: "bigint",
                maxLength: 200,
                nullable: false,
                defaultValue: 0L,
                comment: "PastoralId");
        }
    }
}
