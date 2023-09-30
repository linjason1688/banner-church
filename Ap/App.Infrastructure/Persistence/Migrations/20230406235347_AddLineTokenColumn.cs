using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddLineTokenColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LineToken",
                table: "Pastoral",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "LineToken");

            migrationBuilder.AddColumn<string>(
                name: "LineToken",
                table: "Organization",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "LineToken");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LineToken",
                table: "Pastoral");

            migrationBuilder.DropColumn(
                name: "LineToken",
                table: "Organization");
        }
    }
}
