using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Persistence.Migrations
{
    public partial class AddTableQuestionnaireSatisfyUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceDate",
                table: "UserCourse",
                type: "datetime2",
                nullable: true,
                comment: "AttendanceDate",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "AttendanceDate");

            migrationBuilder.AlterColumn<long>(
                name: "ParentUserId",
                table: "User",
                type: "bigint",
                nullable: true,
                comment: "ParentUserId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "ParentUserId");

            migrationBuilder.CreateTable(
                name: "QuestionnaireSatisfyUser",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionnaireId = table.Column<long>(type: "bigint", maxLength: 30, nullable: false, comment: "QuestionnaireId"),
                    UserId = table.Column<long>(type: "bigint", maxLength: 30, nullable: false, comment: "UserId"),
                    QuestionnaireWriteType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "QuestionnaireWriteType"),
                    QuestionnaireGoArea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "QuestionnaireGoArea"),
                    Satisfaction = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Satisfaction"),
                    Evaluation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Evaluation"),
                    WriteQuestionnaireDate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "WriteQuestionnaireDate"),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "AttendanceDate"),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Memo"),
                    StatusCd = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "1", comment: "StatusCd"),
                    HandledId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "ApiHandledId"),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()", comment: "建立日期"),
                    UserCreate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "建立人員"),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GetDate()", comment: "最後修改日期"),
                    UserUpdate = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "最後修改人員"),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true, comment: "RowVersion")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireSatisfyUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionnaireSatisfyUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireSatisfyUser_DateCreate_UserCreate_HandledId",
                table: "QuestionnaireSatisfyUser",
                columns: new[] { "DateCreate", "UserCreate", "HandledId" });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireSatisfyUser_UserId",
                table: "QuestionnaireSatisfyUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionnaireSatisfyUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AttendanceDate",
                table: "UserCourse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "AttendanceDate",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "AttendanceDate");

            migrationBuilder.AlterColumn<long>(
                name: "ParentUserId",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "ParentUserId",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true,
                oldComment: "ParentUserId");
        }
    }
}
