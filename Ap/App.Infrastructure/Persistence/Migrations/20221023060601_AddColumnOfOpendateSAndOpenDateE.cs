using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddColumnOfOpendateSAndOpenDateE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenDate",
                table: "Course");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDateE",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "OpenDateE");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDateS",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "OpenDateS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenDateE",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "OpenDateS",
                table: "Course");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDate",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "OpenDate");
        }
    }
}
