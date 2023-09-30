using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class addColumnOfRespUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MinistryRespUserStatus",
                table: "MinistryRespUser",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "MinistryRespUserStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinistryRespUserStatus",
                table: "MinistryRespUser");
        }
    }
}
