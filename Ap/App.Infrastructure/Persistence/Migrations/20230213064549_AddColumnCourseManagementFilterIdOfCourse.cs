using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnCourseManagementFilterIdOfCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseManagementFilterId",
                table: "Course",
                type: "bigint",
                maxLength: 200,
                nullable: false,
                defaultValue: 0L,
                comment: "CourseManagementFilterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseManagementFilterId",
                table: "Course");
        }
    }
}
