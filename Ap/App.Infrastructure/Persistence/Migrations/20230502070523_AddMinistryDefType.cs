using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddMinistryDefType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MinistryDefType",
                table: "MinistryDef",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "0",
                comment: "MinistryDefType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinistryDefType",
                table: "MinistryDef");
        }
    }
}
