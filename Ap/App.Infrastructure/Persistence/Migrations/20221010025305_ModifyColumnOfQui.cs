using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnOfQui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseClassNum",
                table: "QuestionnaireDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "CourseClassNum");

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseHomeworkDate",
                table: "QuestionnaireDetail",
                type: "datetime2",
                maxLength: 20,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "CourseHomeworkDate");

            migrationBuilder.AddColumn<string>(
                name: "CourseManagementName",
                table: "QuestionnaireDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "CourseManagementName");

            migrationBuilder.AddColumn<string>(
                name: "CourseManagementNo",
                table: "QuestionnaireDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "CourseManagementNo");

            migrationBuilder.AddColumn<long>(
                name: "CourseManagementTypeId",
                table: "QuestionnaireDetail",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "CourseManagementTypeId");

            migrationBuilder.AddColumn<string>(
                name: "CourseSeason",
                table: "QuestionnaireDetail",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "CourseSeason");

            migrationBuilder.AddColumn<string>(
                name: "CourseYear",
                table: "QuestionnaireDetail",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "CourseYear");

            migrationBuilder.AddColumn<long>(
                name: "PortalId",
                table: "QuestionnaireDetail",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "PortalId");

            migrationBuilder.AddColumn<string>(
                name: "CourseManagementNo",
                table: "CourseManagement",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "CourseManagementNo");

            migrationBuilder.AddColumn<DateTime>(
                name: "HomewokeDate",
                table: "CourseManagement",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "HomewokeDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "HomeworkDate",
                table: "Course",
                type: "datetime2",
                maxLength: 32,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "HomeworkDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseClassNum",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "CourseHomeworkDate",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "CourseManagementName",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "CourseManagementNo",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "CourseManagementTypeId",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "CourseSeason",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "CourseYear",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "PortalId",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "CourseManagementNo",
                table: "CourseManagement");

            migrationBuilder.DropColumn(
                name: "HomewokeDate",
                table: "CourseManagement");

            migrationBuilder.DropColumn(
                name: "HomeworkDate",
                table: "Course");
        }
    }
}
