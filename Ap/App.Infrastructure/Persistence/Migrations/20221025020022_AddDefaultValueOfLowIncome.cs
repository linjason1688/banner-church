using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddDefaultValueOfLowIncome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LowIncome",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "0",
                comment: "LowIncome",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "LowIncome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LowIncome",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                comment: "LowIncome",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "0",
                oldComment: "LowIncome");
        }
    }
}
