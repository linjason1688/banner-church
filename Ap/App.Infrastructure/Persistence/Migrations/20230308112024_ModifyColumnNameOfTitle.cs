using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnNameOfTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleName",
                table: "Dept");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Dept",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Dept");

            migrationBuilder.AddColumn<string>(
                name: "TitleName",
                table: "Dept",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "TitleName");
        }
    }
}
