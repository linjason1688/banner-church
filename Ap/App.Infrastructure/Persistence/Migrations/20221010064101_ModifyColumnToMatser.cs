using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnToMatser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "OrganizationId",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "PortalId",
                table: "QuestionnaireDetail");

            migrationBuilder.AddColumn<string>(
                name: "CourseClassNum",
                table: "Questionnaire",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "CourseClassNum");

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseHomeworkDate",
                table: "Questionnaire",
                type: "datetime2",
                maxLength: 20,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "CourseHomeworkDate");

            migrationBuilder.AddColumn<string>(
                name: "CourseManagementName",
                table: "Questionnaire",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "CourseManagementName");

            migrationBuilder.AddColumn<string>(
                name: "CourseManagementNo",
                table: "Questionnaire",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "CourseManagementNo");

            migrationBuilder.AddColumn<long>(
                name: "CourseManagementTypeId",
                table: "Questionnaire",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "CourseManagementTypeId");

            migrationBuilder.AddColumn<string>(
                name: "CourseSeason",
                table: "Questionnaire",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "CourseSeason");

            migrationBuilder.AddColumn<string>(
                name: "CourseYear",
                table: "Questionnaire",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "CourseYear");

            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                table: "Questionnaire",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "OrganizationId");

            migrationBuilder.AddColumn<long>(
                name: "PortalId",
                table: "Questionnaire",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "PortalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseClassNum",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "CourseHomeworkDate",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "CourseManagementName",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "CourseManagementNo",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "CourseManagementTypeId",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "CourseSeason",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "CourseYear",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Questionnaire");

            migrationBuilder.DropColumn(
                name: "PortalId",
                table: "Questionnaire");

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
                name: "OrganizationId",
                table: "QuestionnaireDetail",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "OrganizationId");

            migrationBuilder.AddColumn<long>(
                name: "PortalId",
                table: "QuestionnaireDetail",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "PortalId");
        }
    }
}
