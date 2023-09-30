using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomewokeDate",
                table: "CourseManagement");

            migrationBuilder.AlterColumn<int>(
                name: "MeetAttendanceType",
                table: "PastoralMeetingUser",
                type: "int",
                maxLength: 36,
                nullable: false,
                defaultValue: 0,
                comment: "MeetAttendanceType",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36,
                oldNullable: true,
                oldComment: "MeetAttendanceType");

            migrationBuilder.AlterColumn<int>(
                name: "MinistryRespUserStatus",
                table: "MinistryRespUser",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0,
                comment: "MinistryRespUserStatus",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "MinistryRespUserStatus");

            migrationBuilder.AlterColumn<int>(
                name: "MeetAttendanceType",
                table: "MinistryMeetingUser",
                type: "int",
                maxLength: 36,
                nullable: false,
                defaultValue: 0,
                comment: "MeetAttendanceType",
                oldClrType: typeof(string),
                oldType: "nvarchar(36)",
                oldMaxLength: 36,
                oldNullable: true,
                oldComment: "MeetAttendanceType");

            migrationBuilder.AddColumn<DateTime>(
                name: "HomeworkDate",
                table: "CourseManagement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "HomeworkDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeworkDate",
                table: "CourseManagement");

            migrationBuilder.AlterColumn<string>(
                name: "MeetAttendanceType",
                table: "PastoralMeetingUser",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true,
                comment: "MeetAttendanceType",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 36,
                oldComment: "MeetAttendanceType");

            migrationBuilder.AlterColumn<string>(
                name: "MinistryRespUserStatus",
                table: "MinistryRespUser",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "MinistryRespUserStatus",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20,
                oldComment: "MinistryRespUserStatus");

            migrationBuilder.AlterColumn<string>(
                name: "MeetAttendanceType",
                table: "MinistryMeetingUser",
                type: "nvarchar(36)",
                maxLength: 36,
                nullable: true,
                comment: "MeetAttendanceType",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 36,
                oldComment: "MeetAttendanceType");

            migrationBuilder.AddColumn<DateTime>(
                name: "HomewokeDate",
                table: "CourseManagement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "HomewokeDate");
        }
    }
}
