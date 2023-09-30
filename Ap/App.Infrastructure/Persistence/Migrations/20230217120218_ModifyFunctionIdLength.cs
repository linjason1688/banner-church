using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyFunctionIdLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParentFunctionId",
                table: "Privilege",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "父層功能 Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true,
                oldComment: "父層功能 Id");

            migrationBuilder.AlterColumn<string>(
                name: "FunctionId",
                table: "Privilege",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "功能 ID",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true,
                oldComment: "功能 ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParentFunctionId",
                table: "Privilege",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                comment: "父層功能 Id",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "父層功能 Id");

            migrationBuilder.AlterColumn<string>(
                name: "FunctionId",
                table: "Privilege",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                comment: "功能 ID",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "功能 ID");
        }
    }
}
