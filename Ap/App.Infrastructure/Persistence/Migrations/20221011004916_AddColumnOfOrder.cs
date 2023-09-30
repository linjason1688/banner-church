using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActuallyAmount",
                table: "ShoppingOrder",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0,
                comment: "ActuallyAmount");

            migrationBuilder.AddColumn<string>(
                name: "Receipt",
                table: "ShoppingOrder",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "Receipt");

            migrationBuilder.AddColumn<long>(
                name: "ReceivePersonId",
                table: "ShoppingOrder",
                type: "bigint",
                maxLength: 20,
                nullable: false,
                defaultValue: 0L,
                comment: "ReceivePersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActuallyAmount",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "Receipt",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "ReceivePersonId",
                table: "ShoppingOrder");
        }
    }
}
