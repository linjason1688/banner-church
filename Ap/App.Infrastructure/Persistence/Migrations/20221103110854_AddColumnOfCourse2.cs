using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnOfCourse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseNoticeDesc",
                table: "Course",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "CourseNoticeDesc");

            migrationBuilder.AddColumn<string>(
                name: "CourseRefundDesc",
                table: "Course",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "CourseRefundDesc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseNoticeDesc",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseRefundDesc",
                table: "Course");
        }
    }
}
