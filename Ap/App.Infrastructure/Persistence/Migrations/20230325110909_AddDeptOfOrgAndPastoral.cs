using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddDeptOfOrgAndPastoral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeptId",
                table: "Pastoral",
                type: "bigint",
                maxLength: 255,
                nullable: false,
                defaultValue: 0L,
                comment: "DeptId");

            migrationBuilder.AddColumn<long>(
                name: "DeptId",
                table: "Organization",
                type: "bigint",
                maxLength: 255,
                nullable: false,
                defaultValue: 0L,
                comment: "DeptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Pastoral");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Organization");
        }
    }
}
