using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnOfCourseManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BasicQualification",
                table: "CourseManagement",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "BasicQualification");

            migrationBuilder.AddColumn<string>(
                name: "GraduationQualification",
                table: "CourseManagement",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "GraduationQualification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasicQualification",
                table: "CourseManagement");

            migrationBuilder.DropColumn(
                name: "GraduationQualification",
                table: "CourseManagement");
        }
    }
}
