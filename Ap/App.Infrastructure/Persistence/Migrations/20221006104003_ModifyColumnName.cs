using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialRequiement",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequirement",
                table: "Course",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "SpecialRequirement");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialRequirement",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "SpecialRequiement",
                table: "Course",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "SpecialRequiement");
        }
    }
}
