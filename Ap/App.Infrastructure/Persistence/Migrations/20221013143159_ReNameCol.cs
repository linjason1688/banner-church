using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ReNameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareIdentityType",
                table: "UserPastoralCare");

            migrationBuilder.AddColumn<string>(
                name: "PastoralTitle",
                table: "UserPastoralCare",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "PastoralTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PastoralTitle",
                table: "UserPastoralCare");

            migrationBuilder.AddColumn<string>(
                name: "CareIdentityType",
                table: "UserPastoralCare",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "CareIdentityType");
        }
    }
}
