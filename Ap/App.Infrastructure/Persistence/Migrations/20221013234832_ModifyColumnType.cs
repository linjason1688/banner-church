using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetingDay",
                table: "PastoralMeeting",
                type: "datetime2",
                maxLength: 36,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "MeetingDay",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36,
                oldNullable: true,
                oldComment: "MeetingDay");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetingDay",
                table: "MinistryMeeting",
                type: "datetime2",
                maxLength: 36,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "MeetingDay",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36,
                oldNullable: true,
                oldComment: "MeetingDay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeetingDay",
                table: "PastoralMeeting",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true,
                comment: "MeetingDay",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 36,
                oldComment: "MeetingDay");

            migrationBuilder.AlterColumn<string>(
                name: "MeetingDay",
                table: "MinistryMeeting",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true,
                comment: "MeetingDay",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 36,
                oldComment: "MeetingDay");
        }
    }
}
