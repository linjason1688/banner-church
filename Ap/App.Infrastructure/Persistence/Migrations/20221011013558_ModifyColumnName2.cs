using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivePersonId",
                table: "ShoppingOrder");

            migrationBuilder.AddColumn<long>(
                name: "ReceiveUserId",
                table: "ShoppingOrder",
                type: "bigint",
                maxLength: 20,
                nullable: false,
                defaultValue: 0L,
                comment: "ReceiveUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiveUserId",
                table: "ShoppingOrder");

            migrationBuilder.AddColumn<long>(
                name: "ReceivePersonId",
                table: "ShoppingOrder",
                type: "bigint",
                maxLength: 20,
                nullable: false,
                defaultValue: 0L,
                comment: "ReceivePersonId");
        }
    }
}
