using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddOrderColumn6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderAddress",
                table: "ShoppingOrder",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "OrderAddress");

            migrationBuilder.AddColumn<string>(
                name: "OrderCellPhone",
                table: "ShoppingOrder",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "OrderCellPhone");

            migrationBuilder.AddColumn<string>(
                name: "OrderEmail",
                table: "ShoppingOrder",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "OrderEmail");

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "ShoppingOrder",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "OrderName");

            migrationBuilder.AddColumn<string>(
                name: "OrderPhone",
                table: "ShoppingOrder",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "OrderPhone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderAddress",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "OrderCellPhone",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "OrderEmail",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "ShoppingOrder");

            migrationBuilder.DropColumn(
                name: "OrderPhone",
                table: "ShoppingOrder");
        }
    }
}
