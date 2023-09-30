using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class modifycolName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefferenceId",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "RefferenceType",
                table: "QrCode");

            migrationBuilder.AddColumn<long>(
                name: "ReferenceId",
                table: "QrCode",
                type: "bigint",
                maxLength: 30,
                nullable: false,
                defaultValue: 0L,
                comment: "ReferenceId");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceType",
                table: "QrCode",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0,
                comment: "ReferenceType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "ReferenceType",
                table: "QrCode");

            migrationBuilder.AddColumn<long>(
                name: "RefferenceId",
                table: "QrCode",
                type: "bigint",
                maxLength: 30,
                nullable: false,
                defaultValue: 0L,
                comment: "RefferenceId");

            migrationBuilder.AddColumn<int>(
                name: "RefferenceType",
                table: "QrCode",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0,
                comment: "RefferenceType");
        }
    }
}
