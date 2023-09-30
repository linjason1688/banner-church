using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddOrgStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrgStatus",
                table: "Organization",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "1",
                comment: "OrgStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrgStatus",
                table: "Organization");
        }
    }
}
