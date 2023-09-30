using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddReqiired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LowIncome",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "0",
                comment: "LowIncome",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "0",
                oldComment: "LowIncome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: "0",
                oldComment: "LowIncome");
        }
    }
}
