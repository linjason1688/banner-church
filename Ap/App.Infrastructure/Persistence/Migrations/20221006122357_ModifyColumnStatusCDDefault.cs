using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnStatusCDDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserSociety",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserQuestionnaire",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserPastoralCare",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserFamily",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserExpertise",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserCourse",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserContract",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "QuestionnaireDetail",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Questionnaire",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "PastoralMeetingUser",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "PastoralMeeting",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Pastoral",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "OrganizationUser",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AddColumn<string>(
                name: "StatusCd",
                table: "Organization",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistrySchedualDetail",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistrySchedual",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistryRespUser",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistryResp",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistryDef",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Ministry",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseTimeSchedualUser",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseTimeSchedualTeacher",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseTimeSchedual",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AddColumn<string>(
                name: "StatusCd",
                table: "CoursePrice",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementType",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilterResp",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilterPastoral",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilterCourse",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilter",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementAppendix",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagement",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseAppendix",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "1",
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "StatusCd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCd",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "StatusCd",
                table: "CoursePrice");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserSociety",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserQuestionnaire",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserPastoralCare",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserFamily",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserExpertise",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserCourse",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "UserContract",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "QuestionnaireDetail",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Questionnaire",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "PastoralMeetingUser",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "PastoralMeeting",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Pastoral",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "OrganizationUser",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistrySchedualDetail",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistrySchedual",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistryRespUser",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistryResp",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "MinistryDef",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Ministry",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseTimeSchedualUser",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseTimeSchedualTeacher",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseTimeSchedual",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementType",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilterResp",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilterPastoral",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilterCourse",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementFilter",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagementAppendix",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseManagement",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "CourseAppendix",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");

            migrationBuilder.AlterColumn<string>(
                name: "StatusCd",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                comment: "StatusCd",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "1",
                oldComment: "StatusCd");
        }
    }
}
