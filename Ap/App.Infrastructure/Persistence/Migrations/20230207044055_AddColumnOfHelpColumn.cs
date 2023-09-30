using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnOfHelpColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsCoupleSameClassHelp",
                table: "ShoppingOrderDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                defaultValue: "0",
                comment: "IsCoupleSameClassHelp");

            migrationBuilder.AddColumn<string>(
                name: "IsCoupleSameClassInformations",
                table: "ShoppingOrderDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "IsCoupleSameClassInformations");

            migrationBuilder.AddColumn<string>(
                name: "IsMoveHelp",
                table: "ShoppingOrderDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                defaultValue: "0",
                comment: "IsMoveHelp");

            migrationBuilder.AddColumn<string>(
                name: "IsOthersHelp",
                table: "ShoppingOrderDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                defaultValue: "0",
                comment: "IsOthersHelp");

            migrationBuilder.AddColumn<string>(
                name: "IsOthersHelpInformations",
                table: "ShoppingOrderDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "IsOthersHelpInformations");

            migrationBuilder.AddColumn<string>(
                name: "IsPregnancyHelp",
                table: "ShoppingOrderDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                defaultValue: "0",
                comment: "IsPregnancyHelp");

            migrationBuilder.AddColumn<string>(
                name: "IsViggieHelp",
                table: "ShoppingOrderDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                defaultValue: "0",
                comment: "IsViggieHelp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCoupleSameClassHelp",
                table: "ShoppingOrderDetail");

            migrationBuilder.DropColumn(
                name: "IsCoupleSameClassInformations",
                table: "ShoppingOrderDetail");

            migrationBuilder.DropColumn(
                name: "IsMoveHelp",
                table: "ShoppingOrderDetail");

            migrationBuilder.DropColumn(
                name: "IsOthersHelp",
                table: "ShoppingOrderDetail");

            migrationBuilder.DropColumn(
                name: "IsOthersHelpInformations",
                table: "ShoppingOrderDetail");

            migrationBuilder.DropColumn(
                name: "IsPregnancyHelp",
                table: "ShoppingOrderDetail");

            migrationBuilder.DropColumn(
                name: "IsViggieHelp",
                table: "ShoppingOrderDetail");
        }
    }
}
