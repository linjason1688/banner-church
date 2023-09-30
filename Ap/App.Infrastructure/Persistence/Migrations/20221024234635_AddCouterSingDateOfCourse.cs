using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddCouterSingDateOfCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SignUpDateS",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: true,
                comment: "SignUpDateS",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 32,
                oldComment: "SignUpDateS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignUpDateE",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: true,
                comment: "SignUpDateE",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 32,
                oldComment: "SignUpDateE");

            migrationBuilder.AddColumn<DateTime>(
                name: "CounterSignUpDateE",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: true,
                comment: "CounterSignUpDateE");

            migrationBuilder.AddColumn<DateTime>(
                name: "CounterSignUpDateS",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: true,
                comment: "CounterSignUpDateS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CounterSignUpDateE",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CounterSignUpDateS",
                table: "Course");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignUpDateS",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "SignUpDateS",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "SignUpDateS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignUpDateE",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "SignUpDateE",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "SignUpDateE");
        }
    }
}
