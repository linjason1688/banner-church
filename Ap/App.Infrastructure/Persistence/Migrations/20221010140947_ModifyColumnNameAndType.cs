using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class ModifyColumnNameAndType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortalId",
                table: "Questionnaire");

            migrationBuilder.AlterColumn<int>(
                name: "Sequence",
                table: "QuestionnaireDetail",
                type: "int",
                maxLength: 32,
                nullable: false,
                defaultValue: 0,
                comment: "Sequence",
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComment: "Sequence");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "QuestionnaireDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "Description");

            migrationBuilder.AddColumn<long>(
                name: "PastoralId",
                table: "Questionnaire",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "PastoralId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "QuestionnaireDetail");

            migrationBuilder.DropColumn(
                name: "PastoralId",
                table: "Questionnaire");

            migrationBuilder.AlterColumn<string>(
                name: "Sequence",
                table: "QuestionnaireDetail",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "Sequence",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 32,
                oldComment: "Sequence");

            migrationBuilder.AddColumn<long>(
                name: "PortalId",
                table: "Questionnaire",
                type: "bigint",
                maxLength: 32,
                nullable: false,
                defaultValue: 0L,
                comment: "PortalId");
        }
    }
}
