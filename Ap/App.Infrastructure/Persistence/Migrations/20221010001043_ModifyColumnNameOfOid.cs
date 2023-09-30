using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnNameOfOid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Oid",
                table: "Organization");

            migrationBuilder.AddColumn<long>(
                name: "UpperOrganizationId",
                table: "Organization",
                type: "bigint",
                maxLength: 255,
                nullable: false,
                defaultValue: 0L,
                comment: "UpperOrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpperOrganizationId",
                table: "Organization");

            migrationBuilder.AddColumn<long>(
                name: "Oid",
                table: "Organization",
                type: "bigint",
                maxLength: 255,
                nullable: false,
                defaultValue: 0L,
                comment: "Oid");
        }
    }
}
