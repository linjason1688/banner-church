using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnNameOfCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassContext",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ClassCount",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "CourseContext",
                table: "Course",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "CourseContext");

            migrationBuilder.AddColumn<int>(
                name: "CourseCount",
                table: "Course",
                type: "int",
                maxLength: 32,
                nullable: false,
                defaultValue: 0,
                comment: "CourseCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseContext",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseCount",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "ClassContext",
                table: "Course",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "ClassContext");

            migrationBuilder.AddColumn<int>(
                name: "ClassCount",
                table: "Course",
                type: "int",
                maxLength: 32,
                nullable: false,
                defaultValue: 0,
                comment: "ClassCount");
        }
    }
}
