using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PastoralId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "PastoralId",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "PastoralId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Birthday",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Birthday");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PastoralId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                comment: "PastoralId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "PastoralId");

            migrationBuilder.AlterColumn<string>(
                name: "Birthday",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Birthday",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Birthday");
        }
    }
}
